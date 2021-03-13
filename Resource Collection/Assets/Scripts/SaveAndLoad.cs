using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveAndLoad {

	public static void Save(GameController gameController, RecipeHolder recipeHolder, ItemImageHolder itemHolder, AssemblyBuilding[] assemblyBuildings, Drone[] drones, Player player)
    {
        SavedClass newSave = new SavedClass();

        newSave.seed = gameController.mapSeed;

        newSave.Images = imageSaves(itemHolder.getImages());

        newSave.items = new Item[itemHolder.getItems().Count];
        for (int i = 0; i < newSave.items.Length; i++)
        {
            newSave.items[i] = itemHolder.getItem(i);
        }
        

        newSave.Recipes = new Recipe[recipeHolder.recipes.Count];
        for (int i = 0; i < newSave.Recipes.Length; i++)
        {
            newSave.Recipes[i] = recipeHolder.recipes[i];
        }



        newSave.assemblySaves = new AssemblySave[assemblyBuildings.Length];

        for (int i = 0; i < newSave.assemblySaves.Length; i++)
        {
            newSave.assemblySaves[i] = new AssemblySave(assemblyBuildings[i].transform.position, assemblyBuildings[i].recipe, assemblyBuildings[i].endItemTotal,
                assemblyBuildings[i].amounts);
        }

        newSave.droneSaves = new DroneSave[drones.Length];

        for (int i = 0; i < newSave.droneSaves.Length; i++)
        {
            if (drones[i].pickUp != null && drones[i].dropOff != null)
            {
                newSave.droneSaves[i] = new DroneSave(drones[i].transform.position, drones[i].hasItem, drones[i].item, drones[i].pickUp.transform.position,
                drones[i].dropOff.transform.position, drones[i].pickUpIsResourceNode, drones[i].pickUpIsAssemblyBuilding);
            }
            else
            {
                newSave.droneSaves[i] = new DroneSave(drones[i].transform.position, drones[i].hasItem, drones[i].item, drones[i].transform.position,
                drones[i].transform.position, drones[i].pickUpIsResourceNode, drones[i].pickUpIsAssemblyBuilding);
            }
            
        }

        newSave.money = player.money;

        newSave.playerX = player.transform.position.x;
        newSave.playerY = player.transform.position.y;

        newSave.droneCost = gameController.droneCost;
        newSave.assemblyCost = gameController.assemblyBuldingCost;
        newSave.newRecipeCost = gameController.newRecipeCost;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.dat");
        bf.Serialize(file, newSave);
        file.Close();

        
    }


    public static void Delete()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.dat"))
        {
            File.Delete(Application.persistentDataPath + "/savedGames.dat");
        }
    }


    public static bool canLoad()
    {

        if(File.Exists(Application.persistentDataPath + "/savedGames.dat"))
        {
            return true;
        }
        else
        {
            return false;
        }

        
    }

    public static SavedClass Load()
    {
        SavedClass newSave = null;

        if (File.Exists(Application.persistentDataPath + "/savedGames.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.dat", FileMode.Open);
            newSave = (SavedClass)bf.Deserialize(file);
            file.Close();
        }

        return newSave;

    }



    public static ImageSave[] imageSaves(List<Image> imgs)
    {
        ImageSave[] images = new ImageSave[imgs.Count];

        for (int i = 0; i < images.Length; i++)
        {
            images[i] = imageSave(imgs[i]);
        }

        return images;
    }

    public static ImageSave imageSave(Image img)
    {
        ImageSave newImage = new ImageSave();

        Color color = img.color;

        newImage.r = color.r;
        newImage.g = color.g;
        newImage.b = color.b;

        Texture2D tex = img.sprite.texture;

        newImage.image = new Pixel[tex.width, tex.height];

        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                newImage.image[x, y] = new Pixel(tex.GetPixel(x, y));
            }
        }



        return newImage;
    }


}


[Serializable]
public class SavedClass
{
    public int seed;
    public int money;

    public int droneCost;
    public int assemblyCost;
    public int newRecipeCost;

    public float playerX;
    public float playerY;

    public ImageSave[] Images;

    public Recipe[] Recipes;

    public Item[] items;

    public AssemblySave[] assemblySaves;

    public DroneSave[] droneSaves;

}

[Serializable]
public class DroneSave
{
    public float x, y;

    public bool hasItem;

    public bool pickUpIsResource;
    public bool pickUpIsAssembly;

    public Item item;

    public float pickUpX, pickUpY;
    public float dropOffX, dropOffY;

    public DroneSave(Vector2 pos, bool hasItem, Item item, Vector2 pickUpPos, Vector2 dropOffPos, bool pickUpIsResource, bool pickUpIsAssembly)
    {
        x = pos.x;
        y = pos.y;

        this.hasItem = hasItem;

        this.item = item;

        pickUpX = pickUpPos.x;
        pickUpY = pickUpPos.y;

        dropOffX = dropOffPos.x;
        dropOffY = dropOffPos.y;

        this.pickUpIsResource = pickUpIsResource;
        this.pickUpIsAssembly = pickUpIsAssembly;
    }


}

[Serializable]
public class AssemblySave
{
    public float x, y;
    public Recipe recipe;
    public int endAmount;

    public List<ItemAmount> amounts;

    public AssemblySave(Vector3 pos, Recipe recipe, int endAmount, List<ItemAmount> amounts)
    {
        x = pos.x;
        y = pos.y;
        this.recipe = recipe;
        this.endAmount = endAmount;
        this.amounts = amounts;
    }
}

[Serializable]
public class ImageSave
{
    public float r, g, b;

    public Pixel[,] image;

}

[Serializable]
public class Pixel
{
    public float r, g, b, a;

    public Pixel(Color color)
    {
        r = color.r;
        g = color.g;
        b = color.b;
        a = color.a;
    }


}







