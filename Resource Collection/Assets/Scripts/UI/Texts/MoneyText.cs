using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour {

    Text text;
    Player player;

	// Use this for initialization
	void Start () {

        text = GetComponent<Text>();
        player = FindObjectOfType<Player>();

	}
	
	// Update is called once per frame
	void Update () {

        if (player != null)
        {
            text.text = "$" + player.money;
        }
        else
        {
            player = FindObjectOfType<Player>();
        }

        

	}
}
