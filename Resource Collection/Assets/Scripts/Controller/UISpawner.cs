using UnityEngine;
using System.Collections;

public class UISpawner : MonoBehaviour {

    Canvas canvas;

    public AssemblyPanel assemblyBuildingUI;
    public BuyPanel buyPanelUI;
    public RecipesPanel recipePanel;


    RecipeHolder recipeHolder;
    ItemImageHolder itemHolder;
    GameController gameController;
    Player player;

    // Use this for initialization
    void Start () {
        recipeHolder = FindObjectOfType<RecipeHolder>();
        itemHolder = FindObjectOfType<ItemImageHolder>();
        canvas = FindObjectOfType<Canvas>();
        player = FindObjectOfType<Player>();
        gameController = FindObjectOfType<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void spawnAssemblyBuildingUI(AssemblyBuilding building)
    {
        AssemblyPanel newPanel = Instantiate(assemblyBuildingUI);

        newPanel.transform.SetParent(canvas.transform);
        newPanel.assemblyBuilding = building;
        newPanel.transform.localPosition = Vector3.zero;
        newPanel.gameController = gameController;
        newPanel.uiSpawner = this;
    }

    public void spawnBuyPanel()
    {
        BuyPanel newPanel = Instantiate(buyPanelUI);

        newPanel.transform.SetParent(canvas.transform);

        RectTransform r = canvas.GetComponent<RectTransform>();
        RectTransform r2 = newPanel.GetComponent<RectTransform>();

        newPanel.transform.localPosition = new Vector3((r.rect.width / 2) - r2.rect.width / 2, 0, 0);
        newPanel.gameController = gameController;
        newPanel.player = player;
    }

    public void spawnRecipesPanel(AssemblyPanel panel)
    {
        RecipesPanel newPanel = Instantiate(recipePanel);

        newPanel.transform.SetParent(canvas.transform);

        RectTransform r = canvas.GetComponent<RectTransform>();
        RectTransform r2 = newPanel.GetComponent<RectTransform>();

        newPanel.transform.localPosition = new Vector3(r.rect.x + (r2.rect.width / 2), r.rect.y + (r2.rect.height / 2), 0);
        newPanel.gameController = gameController;
        newPanel.recipeHolder = recipeHolder;
        newPanel.assemblyPanel = panel;
        newPanel.itemHolder = itemHolder;

    }
}
