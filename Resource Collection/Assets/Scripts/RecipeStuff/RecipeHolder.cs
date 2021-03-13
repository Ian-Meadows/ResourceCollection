using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecipeHolder : MonoBehaviour {

    public List<Recipe> recipes = new List<Recipe>();


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void addNewRecipe(List<RequiredItem> requiredItemsOld, Item output, float craftTime)
    {
        RequiredItem[] reqItems = new RequiredItem[requiredItemsOld.Count];
        requiredItemsOld.CopyTo(reqItems);

        List<RequiredItem> requiredItems = new List<RequiredItem>();
        requiredItems.AddRange(reqItems);
        Recipe recipe = new Recipe(requiredItems, output, craftTime);

        recipes.Add(recipe);
    }

    
}
