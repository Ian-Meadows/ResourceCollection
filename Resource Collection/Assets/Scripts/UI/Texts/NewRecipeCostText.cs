using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewRecipeCostText : MonoBehaviour {

    GameController gameController;
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        gameController = FindObjectOfType<GameController>();

    }
	
	// Update is called once per frame
	void Update () {

        text.text = "New Recipe: $" + gameController.newRecipeCost;

	}
}
