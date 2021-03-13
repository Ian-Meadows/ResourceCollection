using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RecipeButton : MonoBehaviour {

    public Recipe recipe;
    public ItemImageHolder itemHolder;

    public RecipesPanel recipePanel;

    public Text itemName;

    public UnityEngine.UI.Image image;

    // Use this for initialization
    void Start () {

        setName();
        setImage();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void setName()
    {
        itemName.text = recipe.OutputItem.name;
    }

    void setImage()
    {
        Image img = itemHolder.getImage(recipe.OutputItem.ImageLocation);

        image.color = img.color;
        image.sprite = img.sprite;
    }

    public void buttonClicked()
    {
        recipePanel.assemblyPanel.assemblyBuilding.setRecipe(recipe);
        recipePanel.assemblyPanel.selectingRecipe = false;
        recipePanel.assemblyPanel.setRecipe();
    }
}
