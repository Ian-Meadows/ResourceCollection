using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class AssemblyPanel : MonoBehaviour {

    public AssemblyBuilding assemblyBuilding;
    public GameController gameController;
    ItemImageHolder itemHolder;
    RecipeHolder recipeHolder;

    public UISpawner uiSpawner;
    public UnityEngine.UI.Image image;

    public GameObject ViewPort;

    bool changeItemPanels = false;

    List<ItemPanel> itemPanels = new List<ItemPanel>();

    public Text EndTotalText;
    public Text EndItemName;
    public Text ProgressText;

    public Text WorthText;

    public ItemPanel itemPanelPrefab;

    public bool selectingRecipe;

	// Use this for initialization
	void Start () {

        selectingRecipe = false;

        itemHolder = FindObjectOfType<ItemImageHolder>();
        recipeHolder = FindObjectOfType<RecipeHolder>();

        changeItemPanels = true;

        setImage();

    }
	
	// Update is called once per frame
	void Update () {

        setImage();
        setEndTotal();

        if (changeItemPanels)
        {
            ChangeItemPanels();
            changeItemPanels = false;
        }

        if (!assemblyBuilding.UIOpen)
        {
            gameController.mouseIsAvailible = true;
            Destroy(gameObject);
        }
        
        

    }

    void setEndTotal()
    {
        EndTotalText.text = "" + assemblyBuilding.endItemTotal;

        if (assemblyBuilding.recipe != null)
        {
            EndItemName.text = assemblyBuilding.recipe.OutputItem.name;

            float craftingTime = ((float)((int)(assemblyBuilding.recipe.craftingTime * 100))) / 100;

            float time = ((float)((int)(assemblyBuilding.time * 100))) / 100;

            ProgressText.text = time + "/" + craftingTime;

            WorthText.text = "Worth: $"+ assemblyBuilding.recipe.OutputItem.worth;

        }
        else
        {
            EndItemName.text = "No Selected Recipe";
            ProgressText.text = "?";
            WorthText.text = "Worth: $0";
        }
        
    }

    void setImage()
    {
        

        if (assemblyBuilding.recipe != null)
        {
            Image img = itemHolder.getImage(assemblyBuilding.recipe.OutputItem.ImageLocation);
            image.sprite = img.sprite;
            image.color = img.color;
        }
        
    }

    void ChangeItemPanels()
    {

        foreach (ItemPanel i in itemPanels)
        {
            Destroy(i.gameObject);
        }

        itemPanels.Clear();

        float xSpacing = itemPanelPrefab.GetComponent<RectTransform>().rect.width;
        float ySpacing = itemPanelPrefab.GetComponent<RectTransform>().rect.height;


        if (assemblyBuilding.recipe != null)
        {
            List<ItemAmount> amounts = assemblyBuilding.amounts;
            
            for (int y = 0; y < amounts.Count; y++)
            {
                ItemPanel newPanel = Instantiate(itemPanelPrefab);
                newPanel.transform.SetParent(ViewPort.transform);
                newPanel.itemAmount = amounts[y];
                newPanel.itemHolder = itemHolder;
                RectTransform r = newPanel.GetComponent<RectTransform>();
                newPanel.transform.localPosition = new Vector3(r.rect.width / 2, (-r.rect.height / 2) - (ySpacing * y), 0);
                itemPanels.Add(newPanel);

            }

        }
        
    }

    public void setRecipeButton()
    {
        if (!selectingRecipe)
        {
            selectingRecipe = true;
            uiSpawner.spawnRecipesPanel(this);
        }
        
    }

    public void setRecipe()
    {
        changeItemPanels = true;
    }

    public void MouseAvalible()
    {
        gameController.mouseIsAvailible = true;
    }
    public void MouseNotAvalible()
    {
        gameController.mouseIsAvailible = false;
    }
}
