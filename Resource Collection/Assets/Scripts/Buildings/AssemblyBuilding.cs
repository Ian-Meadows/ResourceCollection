using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class AssemblyBuilding : BasicBuilding
{
    public Canvas canvas;

    UISpawner uiSpawner;

    public bool UIOpen;

    public Recipe recipe;
    public int endItemTotal;

    GameController gameController;

    public List<ItemAmount> amounts = new List<ItemAmount>();

    bool waitFrame = false;

    bool crafting = false;

    public float time = 0;

    public ItemImage itemImagePrefab;

    public bool useStart = true;

    // Use this for initialization
    void Start () {

        UIOpen = false;
        canvas = FindObjectOfType<Canvas>();
        uiSpawner = FindObjectOfType<UISpawner>();
        gameController = FindObjectOfType<GameController>();

        ItemImage newItemImage = Instantiate(itemImagePrefab);
        newItemImage.transform.SetParent(transform);
        newItemImage.assemblyBuilding = this;
        newItemImage.showsDrone = false;
        newItemImage.transform.localPosition = Vector3.zero;

        if (useStart)
        {
            time = 0;

            
            endItemTotal = 0;
            setRecipe(null);

            
        }

        

    }
	
	// Update is called once per frame
	void Update () {
        input();
        waitFrame = false;

        if (crafting)
        {
            craft();
        }

    }

    public override void itemGiven(Item item)
    {
        foreach (ItemAmount amount in amounts)
        {
            if (item.ItemType == amount.ItemType)
            {
                amount.total++;
                
            }
        }
        if (recipe != null)
        {
            checkForEnough();
        }
        
    }

    void OnMouseDown()
    {
        if (gameController.mouseIsAvailible)
        {
            if (!UIOpen)
            {
                uiSpawner.spawnAssemblyBuildingUI(this);
                waitFrame = true;
            }

            UIOpen = true;
            

        }
    }

    void craft()
    {
        time += Time.deltaTime;
        if (time >= recipe.craftingTime)
        {
            time = 0;
            endItemTotal++;
            crafting = false;
            checkForEnough();
        }
    }

    void checkForEnough()
    {
        bool hasEnough = true;

        foreach (ItemAmount amount in amounts)
        {
            if (amount.total < amount.needed)
            {
                hasEnough = false;

            }
        }

        if (hasEnough && !crafting)
        {
            foreach (ItemAmount amount in amounts)
            {
                amount.total -= amount.needed;
            }

            crafting = true;
        }
    }

    void input()
    {
        if (UIOpen)
        {
            if (gameController.mouseIsAvailible && Input.GetMouseButtonDown(0) && !waitFrame)
            {
                UIOpen = false;
            }
        }
    }

    public void setRecipe(Recipe recipeChange)
    {
        if (recipe != recipeChange)
        {
            endItemTotal = 0;
        }

        recipe = recipeChange;
        amounts.Clear();
        if (recipe != null)
        {
            foreach (RequiredItem requiredItem in recipe.requiredItems)
            {
                amounts.Add(new ItemAmount(requiredItem.amount, requiredItem.ItemType));
            }
        }
        
        

    }

    public Item RetrieveItem()
    {
        if (endItemTotal > 0)
        {
            endItemTotal--;
            return recipe.OutputItem;
        }
        else
        {
            return null;
        }
        
    }


}

[Serializable]
public class ItemAmount
{
    public int total;
    public int needed;
    public int ItemType;

    public ItemAmount(int needed, int ItemType)
    {
        total = 0;
        this.needed = needed;
        this.ItemType = ItemType;
    }
}
