using UnityEngine;
using System.Collections;
using System;

public class HomeBuilding : BasicBuilding
{
    Player player;



    // Use this for initialization
    void Start () {

        player = FindObjectOfType<Player>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void itemGiven(Item item)
    {
        if (item!=null)
        {
            player.money += item.worth;
        }
        
    }



}
