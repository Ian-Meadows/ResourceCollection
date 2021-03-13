using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecipeCreator : MonoBehaviour {

    RecipeHolder recipeHolder;
    ImageGenerator imageGen;
    ItemCreator itemCreator;
    ItemImageHolder itemHolder;

    public Sprite Plate;
    public Sprite Wire;

	// Use this for initialization
	void Start () {

        recipeHolder = FindObjectOfType<RecipeHolder>();
        imageGen = FindObjectOfType<ImageGenerator>();
        itemCreator = FindObjectOfType<ItemCreator>();
        itemHolder = FindObjectOfType<ItemImageHolder>();

        Load load = FindObjectOfType<Load>();
        if (load.newSave)
        {
            starterItems();
        }
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void starterItems()
    {
        List<RequiredItem> requiredItems = new List<RequiredItem>();
        //iron plate
        requiredItems.Add(new RequiredItem(itemHolder.getItem("Iron Ore").ItemType, 1));
        requiredItems.Add(new RequiredItem(itemHolder.getItem("Coal Ore").ItemType, 1));


        Item item = itemCreator.CreateItem(new Image(Plate, new Color(1, .62f, .62f), imageGen), 4, "Iron Plate", Item.ItemBase.Plate);
        recipeHolder.addNewRecipe(requiredItems, item, 0.5f);

        //copper plate
        requiredItems.Clear();

        requiredItems.Add(new RequiredItem(itemHolder.getItem("Copper Ore").ItemType, 1));
        requiredItems.Add(new RequiredItem(itemHolder.getItem("Coal Ore").ItemType, 1));

        item = itemCreator.CreateItem(new Image(Plate, new Color(1, 0.447f, 0), imageGen), 4, "Copper Plate", Item.ItemBase.Plate);
        recipeHolder.addNewRecipe(requiredItems, item, 0.5f);

        //gold plate
        requiredItems.Clear();

        requiredItems.Add(new RequiredItem(itemHolder.getItem("Gold Ore").ItemType, 1));
        requiredItems.Add(new RequiredItem(itemHolder.getItem("Coal Ore").ItemType, 1));

        item = itemCreator.CreateItem(new Image(Plate, new Color(.61f, .61f, 0), imageGen), 12, "Gold Plate", Item.ItemBase.Plate);
        recipeHolder.addNewRecipe(requiredItems, item, 0.5f);


        //copper Wire
        requiredItems.Clear();

        requiredItems.Add(new RequiredItem(itemHolder.getItem("Copper Plate").ItemType, 2));
        

        item = itemCreator.CreateItem(new Image(Wire, new Color(1, 0.447f, 0), imageGen), 6, "Copper Wire", Item.ItemBase.Wire);
        recipeHolder.addNewRecipe(requiredItems, item, 0.5f);


        //gold Wire
        requiredItems.Clear();

        requiredItems.Add(new RequiredItem(itemHolder.getItem("Gold Plate").ItemType, 2));
        

        item = itemCreator.CreateItem(new Image(Wire, new Color(.61f, .61f, 0), imageGen), 16, "Gold Wire", Item.ItemBase.Wire);
        recipeHolder.addNewRecipe(requiredItems, item, 0.5f);

        newProcessor();

    }


    public void createNewRecipe()
    {
        
        if (Random.value < 0.2f)
        {
            newComputer();
        }
        else if(Random.value < 0.3f)
        {
            newProcessor();
        }
        else if (Random.value < 0.5f)
        {
            newWireRecipe();
        }
        else
        {
            newPlateRecipe();
        }
        
    }



    void newPlateRecipe()
    {
        List<RequiredItem> requiredItems = new List<RequiredItem>();

        List<Item> usableItems = new List<Item>();

        usableItems.AddRange(itemHolder.Plates);

        usableItems.AddRange(itemHolder.Ores);

        int total = itemHolder.getItemLength();

        int totalHad = 0;

        int worth = 0;

        bool isDone = false;

        int itemAmount = 0;

        while (!isDone)
        {
            requiredItems.Clear();
            totalHad = 0;
            worth = 0;
            for (int i = 0; i < usableItems.Count; i++)
            {
                if (Random.value < .3f)
                {
                    itemAmount = Random.Range(1, 6);
                    requiredItems.Add(new RequiredItem(usableItems[i].ItemType, itemAmount));
                    worth += usableItems[i].worth * itemAmount;
                    totalHad++;
                }
            }

            if (totalHad >= 2)
            {
                isDone = true;
            }
        }
        itemAmount = Random.Range(1, 6);
        requiredItems.Add(new RequiredItem(itemHolder.Coal.ItemType, itemAmount));

        worth += itemHolder.Coal.worth * itemAmount;

        worth = (int)(worth / 1.5f);

        string ItemName = NameGenerator.generateName();

        Color color = ColorGenerator.generatorColor();


        Item item = itemCreator.CreateItem(new Image(Plate, color, imageGen), worth, ItemName + " Plate", Item.ItemBase.Plate);
        recipeHolder.addNewRecipe(requiredItems, item, Random.Range(0.5f, 5.0f));
    }


    void newWireRecipe()
    {
        List<RequiredItem> requiredItems = new List<RequiredItem>();

        List<Item> usableItems = new List<Item>();

        usableItems.AddRange(itemHolder.Plates);

        usableItems.AddRange(itemHolder.Wires);

        int total = itemHolder.getItemLength();

        int totalHad = 0;

        int worth = 0;

        bool isDone = false;

        int itemAmount = 0;

        while (!isDone)
        {
            requiredItems.Clear();
            totalHad = 0;
            worth = 0;
            for (int i = 0; i < usableItems.Count; i++)
            {
                if (Random.value < .3f)
                {
                    itemAmount = Random.Range(1, 6);
                    requiredItems.Add(new RequiredItem(usableItems[i].ItemType, itemAmount));
                    worth += usableItems[i].worth * itemAmount;
                    totalHad++;
                }
            }

            if (totalHad >= 2)
            {
                isDone = true;
            }
        }
        

        worth = (int)(worth / 1.2f);

        string ItemName = NameGenerator.generateName();

        Color color = ColorGenerator.generatorColor();


        Item item = itemCreator.CreateItem(new Image(Wire, color, imageGen), worth, ItemName + " Wire", Item.ItemBase.Wire);
        recipeHolder.addNewRecipe(requiredItems, item, Random.Range(0.5f, 10.0f));
    }

    void newProcessor()
    {
        List<RequiredItem> requiredItems = new List<RequiredItem>();

        List<Item> usableItems = new List<Item>();

        usableItems.AddRange(itemHolder.Plates);

        usableItems.AddRange(itemHolder.Wires);

        usableItems.AddRange(itemHolder.Processers);

        int total = itemHolder.getItemLength();

        int totalHad = 0;

        int worth = 0;

        bool isDone = false;

        int itemAmount = 0;

        bool hasWire = false;
        bool hasPlate = false;

        while (!isDone)
        {
            hasWire = false;
            hasPlate = false;
            requiredItems.Clear();
            totalHad = 0;
            worth = 0;
            for (int i = 0; i < usableItems.Count; i++)
            {
                if (Random.value < .3f)
                {
                    itemAmount = Random.Range(1, 6);
                    requiredItems.Add(new RequiredItem(usableItems[i].ItemType, itemAmount));
                    worth += usableItems[i].worth * itemAmount;
                    totalHad++;
                    if (usableItems[i].itemBase == Item.ItemBase.Wire)
                    {
                        hasWire = true;
                    }

                    if (usableItems[i].itemBase == Item.ItemBase.Plate)
                    {
                        hasPlate = true;
                    }

                }
            }

            if (totalHad >= 2 && hasWire && hasPlate)
            {
                isDone = true;
            }
        }


        worth = (int)(worth * 1.1f);

        string ItemName = NameGenerator.generateName();

        Color color = new Color(1, 1, 1);


        Item item = itemCreator.CreateItem(new Image(imageGen.ProcessorSprite(), color, imageGen), worth, ItemName + " Processor", Item.ItemBase.Processor);
        recipeHolder.addNewRecipe(requiredItems, item, Random.Range(2f, 20.0f));
    }



    void newComputer()
    {
        List<RequiredItem> requiredItems = new List<RequiredItem>();

        List<Item> usableItems = new List<Item>();

        usableItems.AddRange(itemHolder.Plates);

        usableItems.AddRange(itemHolder.Wires);

        usableItems.AddRange(itemHolder.Processers);

        usableItems.AddRange(itemHolder.Computers);

        int total = itemHolder.getItemLength();

        int totalHad = 0;

        int worth = 0;

        bool isDone = false;

        int itemAmount = 0;

        bool hasWire = false;
        bool hasPlate = false;
        bool hasProcessor = false;

        while (!isDone)
        {
            hasWire = false;
            hasPlate = false;
            hasProcessor = false;
            requiredItems.Clear();
            totalHad = 0;
            worth = 0;
            for (int i = 0; i < usableItems.Count; i++)
            {
                if (Random.value < .3f)
                {
                    itemAmount = Random.Range(1, 6);
                    requiredItems.Add(new RequiredItem(usableItems[i].ItemType, itemAmount));
                    worth += usableItems[i].worth * itemAmount;
                    totalHad++;
                    if (usableItems[i].itemBase == Item.ItemBase.Wire)
                    {
                        hasWire = true;
                    }

                    if (usableItems[i].itemBase == Item.ItemBase.Plate)
                    {
                        hasPlate = true;
                    }

                    if (usableItems[i].itemBase == Item.ItemBase.Processor)
                    {
                        hasProcessor = true;
                    }

                }
            }

            if (totalHad >= 2 && hasWire && hasPlate && hasProcessor)
            {
                isDone = true;
            }
        }

        worth = (int)(worth * 1.4f);


        string ItemName = NameGenerator.generateName();

        Color color = new Color(1, 1, 1);


        Item item = itemCreator.CreateItem(new Image(imageGen.ComputerSprite(), color, imageGen), worth, ItemName + " Computer", Item.ItemBase.Computer);
        recipeHolder.addNewRecipe(requiredItems, item, Random.Range(5.0f, 30.0f));
    }


}




public static class ColorGenerator
{
    public static Color generatorColor()
    {
        float r = 0;
        float g = 0;
        float b = 0;

        bool isDone = false;

        while (!isDone)
        {
            r = Random.value;
            g = Random.value;
            b = Random.value;
            
            if (r + g + b > 0.2f)
            {
                isDone = true;
            }


        }


        Color color = new Color(r, g, b);

        return color;
    }
}

public static class NameGenerator{

    static string[] names = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N" };


    public static string generateName()
    {

        string name = "";

        int length = Random.Range(1, 8);

        for (int i = 0; i < length; i++)
        {
            name += names[Random.Range(0, names.Length)];
        }

        



        return name;
    }
}
