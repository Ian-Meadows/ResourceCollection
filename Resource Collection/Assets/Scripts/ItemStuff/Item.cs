using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Item {

    public int worth;

    public string name;

    public int ItemType;

    public int ImageLocation;

    public enum ItemBase {Coal, Ore, Plate, Wire, Processor, Computer};

    public ItemBase itemBase = new ItemBase();


	public Item(int ItemType, ItemImageHolder itemHolder)
    {
        Item baseItem = itemHolder.getItem(ItemType);

        this.ItemType = ItemType;
        worth = baseItem.worth;
        name = baseItem.name;
        ImageLocation = baseItem.ImageLocation;
        itemBase = baseItem.itemBase;
    }

    public Item(int ItemType, int worth, string name, int ImageLocation, ItemBase itemBase)
    {
        this.ItemType = ItemType;
        this.worth = worth;
        this.name = name;
        this.ImageLocation = ImageLocation;
        this.itemBase = itemBase;
    }
}
