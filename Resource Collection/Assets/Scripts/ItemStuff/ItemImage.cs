using UnityEngine;
using System.Collections;

public class ItemImage : MonoBehaviour {

    public Sprite emptySprite;

    public Drone drone;
    public AssemblyBuilding assemblyBuilding;
    Sprite sprite;
    SpriteRenderer spriteRenderer;
    ItemImageHolder itemHolder;

    Recipe recipe;
    Item item;

    public bool showsDrone;

    bool hasSprite = false;

	// Use this for initialization
	void Start () {
        itemHolder = FindObjectOfType<ItemImageHolder>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (showsDrone)
        {
            spriteRenderer.sortingOrder = 25;
        }
        else
        {
            spriteRenderer.sortingOrder = 25;
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (showsDrone)
        {
            droneStuff();
        }
        else
        {
            assemblyStuff();
        }

        

    }


    void droneStuff()
    {

        if (item != drone.item)
        {
            hasSprite = false;
        }

        

        if (hasSprite)
        {
            if (drone.item == null)
            {
                //sprite = new Sprite();
                sprite = emptySprite;
                hasSprite = false;
            }
        }
        else
        {
            if (drone.item != null)
            {
                Image image = itemHolder.getImage(drone.item.ImageLocation);
                sprite = image.sprite;
                spriteRenderer.color = image.color;

                hasSprite = true;
            }
        }
        spriteRenderer.sprite = sprite;
    }

    void assemblyStuff()
    {
        if (recipe != assemblyBuilding.recipe)
        {
            hasSprite = false;
        }

        

        if (hasSprite)
        {
            if (assemblyBuilding.recipe == null)
            {
                sprite = emptySprite;
                hasSprite = false;
            }
        }
        else
        {
            if (assemblyBuilding.recipe != null)
            {
                Image image = itemHolder.getImage(assemblyBuilding.recipe.OutputItem.ImageLocation);
                sprite = image.sprite;
                spriteRenderer.color = image.color;

                hasSprite = true;
            }
        }
        spriteRenderer.sprite = sprite;
    }

}
