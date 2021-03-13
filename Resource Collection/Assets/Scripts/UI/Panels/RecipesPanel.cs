using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecipesPanel : MonoBehaviour {

    public RecipeButton recipeButtonPrefab;

    public RecipeHolder recipeHolder;
    public ItemImageHolder itemHolder;

    public GameObject ViewPort;

    public AssemblyPanel assemblyPanel;

    public GameController gameController;

    // Use this for initialization
    void Start () {

        spawnButtons();

    }
	
	// Update is called once per frame
	void Update () {

        if (assemblyPanel != null)
        {
            if (!assemblyPanel.selectingRecipe)
            {
                gameController.mouseIsAvailible = true;
                Destroy(gameObject);
            }
        }
        else
        {
            gameController.mouseIsAvailible = true;
            Destroy(gameObject);
        }
        

	}


    void spawnButtons()
    {

        List<Recipe> recipes = recipeHolder.recipes;

        bool goX = false;

        float y = 0;

        float width = recipeButtonPrefab.GetComponent<RectTransform>().rect.width;
        float height = recipeButtonPrefab.GetComponent<RectTransform>().rect.height;

        for (int i = 0; i < recipes.Count; i++)
        {
            RecipeButton newButton = Instantiate(recipeButtonPrefab);

            newButton.transform.SetParent(ViewPort.transform);


            RectTransform r = ViewPort.GetComponent<RectTransform>();
            RectTransform r2 = newButton.GetComponent<RectTransform>();

            if (goX)
            {
                newButton.transform.localPosition = new Vector3(r2.rect.width + (width / 2) + 5, (-r2.rect.height / 2) - y, 0);
                y += height + 5;
            }
            else
            {
                newButton.transform.localPosition = new Vector3(r2.rect.width / 2, (-r2.rect.height / 2) - y, 0);
            }
            
            
            newButton.recipe = recipes[i];
            newButton.itemHolder = itemHolder;
            newButton.recipePanel = this;

            goX = !goX;

        }
    }

    public void MouseAvalible()
    {
        gameController.mouseIsAvailible = true;
    }
    public void MouseNotAvalible()
    {
        gameController.mouseIsAvailible = false;
    }
}
