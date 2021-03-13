using UnityEngine;
using System.Collections;



public class BasicResourceNode : BasicObject
{
    public int worth;

    public int itemLocation;

    ItemImageHolder itemHolder;

    public void setUp()
    {
        itemHolder = FindObjectOfType<ItemImageHolder>();
    }

    public Item getItem()
    {
        return itemHolder.getItem(itemLocation);
    }

}
