using UnityEngine;
using System.Collections;

public class ItemCreator : MonoBehaviour {

    ItemImageHolder itemHolder;
    ImageGenerator imageGenerator;

    public Sprite ResourceNode;


	// Use this for initialization
	void Start () {
        itemHolder = FindObjectOfType<ItemImageHolder>();
        imageGenerator = FindObjectOfType<ImageGenerator>();

        Load load = FindObjectOfType<Load>();

        if (load.newSave)
        {
            createNewItem(new Image(ResourceNode, new Color(1, .62f, .62f), imageGenerator), 1, "Iron Ore", Item.ItemBase.Ore);
            createNewItem(new Image(ResourceNode, new Color(1, 0.447f, 0), imageGenerator), 1, "Copper Ore", Item.ItemBase.Ore);
            createNewItem(new Image(ResourceNode, new Color(.61f, .61f, 0), imageGenerator), 2, "Gold Ore", Item.ItemBase.Ore);
            createNewItem(new Image(ResourceNode, new Color(0, 0, 0), imageGenerator), 1, "Coal Ore", Item.ItemBase.Coal);
        }
        


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void createNewItem(Image image, int worth, string name, Item.ItemBase itemBase)
    {
        itemHolder.addImage(image);

        itemHolder.addItem(new Item(itemHolder.getItemLength(), worth, name, itemHolder.getItemLength(), itemBase));

    }

    public Item CreateItem(Image image, int worth, string name, Item.ItemBase itemBase)
    {
        
        itemHolder.addImage(image);

        Item item = new Item(itemHolder.getItemLength(), worth, name, itemHolder.getItemLength(), itemBase);
        
        itemHolder.addItem(item);

        return item;
    }



}
