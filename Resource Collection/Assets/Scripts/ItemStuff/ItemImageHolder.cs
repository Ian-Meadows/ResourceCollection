using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemImageHolder : MonoBehaviour {

    List<Image> ItemImages = new List<Image>();

    List<Item> ItemList = new List<Item>();

    public List<Item> Plates = new List<Item>();

    public Item Coal;

    public List<Item> Ores = new List<Item>();

    public List<Item> Wires = new List<Item>();

    public List<Item> Processers = new List<Item>();

    public List<Item> Computers = new List<Item>();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public Image getImage(int index)
    {

        if (ItemImages.Count < index)
        {
            return null;
        }
        else
        {
            return ItemImages[index];
        }


    }

    public Item getItem(int index)
    {
        if (ItemList.Count < index)
        {
            return null;
        }
        else
        {
            return ItemList[index];
        }
    }

    public Item getItem(string name)
    {
        
        foreach (Item item in ItemList)
        {
            if (item.name.Equals(name))
            {
                return item;
            }
        }
        return null;
    }

    public void addItem(Item item)
    {
        ItemList.Add(item);

        if (item.itemBase == Item.ItemBase.Ore)
        {
            Ores.Add(item);
        }
        else if (item.itemBase == Item.ItemBase.Coal)
        {
            Coal = item;
        }
        else if (item.itemBase == Item.ItemBase.Plate)
        {
            Plates.Add(item);
        }
        else if (item.itemBase == Item.ItemBase.Wire)
        {
            Wires.Add(item);
        }
        else if (item.itemBase == Item.ItemBase.Processor)
        {
            Processers.Add(item);
        }
        else if (item.itemBase == Item.ItemBase.Computer)
        {
            Computers.Add(item);
        }

    }

    public void addImage(Image image)
    {
        ItemImages.Add(image);
    }

    public int getItemLength()
    {
        return ItemList.Count;
    }

    public int getImageLength()
    {
        return ItemImages.Count;
    }

    public List<Image> getImages()
    {
        return ItemImages;
    }
    
    public List<Item> getItems()
    {
        return ItemList;
    }

    public void addItemsandImages(List<Item> items, List<Image> images)
    {
        for (int i = 0; i < images.Count; i++)
        {
            addImage(images[i]);
            addItem(items[i]);
        }
    }

}


public class Image{

    public Sprite sprite;
    public Color color;

    public Image(Sprite sprite, Color color, ImageGenerator imageGen)
    {

        

        this.color = color;
        this.sprite = imageGen.spriteToSprite(sprite);
    }

    

}
