using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public LeaveButton leaveButtonPrefab;

    public bool leaveOption;

    Canvas canvas;
    UISpawner uiSpawner;
    RecipeCreator recipeCreator;
    Player player;

    public bool mouseIsAvailible;

    public int droneCost;
    public int assemblyBuldingCost;

    public int newRecipeCost;

    public bool buyPanelOpen;

    public enum BuildMode { none, drone, assemblyBuilding}
    public BuildMode buildMode = new BuildMode();

    public Drone dronePrefab;
    public AssemblyBuilding assemblyPrefab;

    public int mapSeed;

    public bool useStart = true;

	// Use this for initialization
	void Start () {
        if (useStart)
        {
            droneCost = 5;
            assemblyBuldingCost = 50;
            newRecipeCost = 200;
        }
        
        leaveOption = false;
        canvas = FindObjectOfType<Canvas>();
        mouseIsAvailible = true;
        buyPanelOpen = false;
        uiSpawner = FindObjectOfType<UISpawner>();
        buildMode = BuildMode.none;

        recipeCreator = FindObjectOfType<RecipeCreator>();
        player = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update () {

        input();

	}

    void input()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (leaveOption)
            {
                leaveOption = false;
            }
            else
            {
                leaveOption = true;

                LeaveButton newLeaveButton = Instantiate(leaveButtonPrefab);
                newLeaveButton.transform.SetParent(canvas.transform);
                newLeaveButton.transform.localPosition = Vector3.zero;
                newLeaveButton.gameController = this;


            }
        }


        if (Input.GetKeyDown(KeyCode.B))
        {
            if (buyPanelOpen)
            {
                buyPanelOpen = false;
            }
            else
            {
                buyPanelOpen = true;
                uiSpawner.spawnBuyPanel();
            }
        }


        if (Input.GetMouseButtonDown(0) && mouseIsAvailible && buildMode == BuildMode.none)
        {
            buyPanelOpen = false;
        }

        if (Input.GetMouseButtonDown(0) && mouseIsAvailible && buildMode == BuildMode.drone)
        {
            Instantiate(dronePrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 9), Quaternion.identity);
            buildMode = BuildMode.none;
        }

        if (Input.GetMouseButtonDown(0) && mouseIsAvailible && buildMode == BuildMode.assemblyBuilding)
        {
            Instantiate(assemblyPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10), Quaternion.identity);
            buildMode = BuildMode.none;
        }

    }

    public void newRecipe()
    {
        if (player.money >= newRecipeCost)
        {
            player.money -= newRecipeCost;
            newRecipeCost += 100;
            recipeCreator.createNewRecipe();
        }
        
    }
    

}
