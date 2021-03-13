using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Recipe {

    public Item OutputItem;

    public List<RequiredItem> requiredItems = new List<RequiredItem>();

    public float craftingTime;

    public Recipe(List<RequiredItem> requiredItems, Item OutputItem, float craftingTime)
    {
        this.requiredItems = requiredItems;
        this.OutputItem = OutputItem;
        this.craftingTime = craftingTime;
    }


}

[Serializable]
public class RequiredItem
{
    public int ItemType;
    public int amount;

    public RequiredItem(int ItemType, int amount)
    {
        this.ItemType = ItemType;
        this.amount = amount;
    }
   


}
