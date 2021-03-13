using UnityEngine;
using System.Collections;

public abstract class BasicBuilding : BasicObject
{
    public abstract void itemGiven(Item item);

    public void giveItem(Item item)
    {
        itemGiven(item);
    }
	
}
