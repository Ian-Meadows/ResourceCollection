using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyPanel : MonoBehaviour {

    public GameController gameController;
    public Player player;

    public Text DroneText;

    public Text AssemblyText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        setDroneCost();
        SetAssemblyCost();

        if (!gameController.buyPanelOpen)
        {
            gameController.mouseIsAvailible = true;
            Destroy(gameObject);
        }

    }


    void setDroneCost()
    {
        DroneText.text = "Drone \n" + "$" + gameController.droneCost;
    }

    void SetAssemblyCost()
    {
        AssemblyText.text = "Assembly Building \n" + "$" + gameController.assemblyBuldingCost;
    }

    public void mouseAvalible()
    {
        gameController.mouseIsAvailible = true;
    }

    public void mouseNotAvalible()
    {
        gameController.mouseIsAvailible = false;
    }



    public void buyDrone()
    {
        if (player.money >= gameController.droneCost)
        {
            player.money -= gameController.droneCost;

            gameController.droneCost += 1;

            gameController.buildMode = GameController.BuildMode.drone;
        }
        
    }

    public void buyAssembly()
    {
        if (player.money >= gameController.assemblyBuldingCost)
        {
            player.money -= gameController.assemblyBuldingCost;

            gameController.assemblyBuldingCost += 10;

            gameController.buildMode = GameController.BuildMode.assemblyBuilding;
        }
    }
}
