using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {



    public bool newSave;

    public int waitTime = 10;

    public SavedClass savedClass;

    bool hasLoaded = false;

    public AssemblyBuilding assemblyPrefab;
    public Drone dronePrefab;

    // Use this for initialization
    void Start () {

        DontDestroyOnLoad(gameObject);

        if (!SaveAndLoad.canLoad())
        {
            newSave = true;
        }
        else
        {
            newSave = false;


            savedClass = SaveAndLoad.Load();

        }

    }
	
	// Update is called once per frame
	void Update () {
        
        if (SceneManager.GetActiveScene().name == "Game")
        {

            if (!hasLoaded && !newSave)
            {
                load();
                hasLoaded = true;
            }

            if (waitTime <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                waitTime--;
            }
        }
        

	}

    public void justDeletedSave()
    {
        if (!SaveAndLoad.canLoad())
        {
            newSave = true;
        }
        else
        {
            newSave = false;


            savedClass = SaveAndLoad.Load();

        }
    }

    void load()
    {
        ItemImageHolder itemHolder = FindObjectOfType<ItemImageHolder>();
        List<Image> imgs = new List<Image>();
        List<Item> items = new List<Item>();
        items.AddRange(savedClass.items);

        ImageGenerator gen = FindObjectOfType<ImageGenerator>();

        for (int i = 0; i < savedClass.Images.Length; i++)
        {
            imgs.Add(saveToSprite(savedClass.Images[i], gen));
        }

        itemHolder.addItemsandImages(items, imgs);

        RecipeHolder recipeHolder = FindObjectOfType<RecipeHolder>();
        recipeHolder.recipes.AddRange(savedClass.Recipes);

        GameController gameController = FindObjectOfType<GameController>();
        gameController.newRecipeCost = savedClass.newRecipeCost;
        gameController.droneCost = savedClass.droneCost;
        gameController.assemblyBuldingCost = savedClass.assemblyCost;

        gameController.useStart = false;

    }


    

    


    public Image saveToSprite(ImageSave save, ImageGenerator gen)
    {
        

        Texture2D tex = new Texture2D(save.image.GetLength(0), save.image.GetLength(1));

        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                tex.SetPixel(x, y, new Color(save.image[x, y].r, save.image[x, y].g, save.image[x, y].b, save.image[x, y].a));
            }
        }


        tex.Apply();



        Sprite outSprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);



        return new Image(outSprite, new Color(save.r, save.g, save.b), gen);
    }
    
}
