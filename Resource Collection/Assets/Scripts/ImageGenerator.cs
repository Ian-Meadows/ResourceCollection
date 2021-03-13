using UnityEngine;
using System.Collections;

public class ImageGenerator : MonoBehaviour {

    int sizeX = 50;
    int sizeY = 50;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Sprite spriteToSprite(Sprite spriteIn)
    {
        Texture2D texureIn = spriteIn.texture;
        Texture2D tex = new Texture2D(sizeX, sizeY);
        int sizeChange = texureIn.width / tex.width;
        

        for (int x = 0; x < texureIn.width; x ++)
        {
            for (int y = 0; y < texureIn.height; y++)
            {
                if (x % sizeChange == 0 && y % sizeChange == 0)
                {
                    tex.SetPixel(x / sizeChange, y / sizeChange, texureIn.GetPixel(x, y));
                }
            }
        }
        tex.Apply();


        
        Sprite outSprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        


        return outSprite;
    }

    public Sprite ComputerSprite()
    {
        Texture2D tex = new Texture2D(sizeX, sizeY);

        Color baseColor = ColorGenerator.generatorColor();

        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                tex.SetPixel(x, y, baseColor);
            }
        }

        Color colorBlack = new Color(0, 0, 0);

        int size = 15;

        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {

                if (x > size && y > size && y < tex.height - size && x < tex.width - size)
                {
                    tex.SetPixel(x, y, colorBlack);
                }

                
            }
        }


        tex.Apply();
        Sprite outSprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        return outSprite;
    }


    public Sprite ProcessorSprite()
    {
        Texture2D tex = new Texture2D(sizeX, sizeY);

        Color baseColor = ColorGenerator.generatorColor();


        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                tex.SetPixel(x, y, baseColor);
            }
        }

        Color wireColor = ColorGenerator.generatorColor();

        int height = 0;

        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                if (x > (tex.width / 2) - 2 + height && y < (tex.height / 3) + 2 + height && y > (tex.height / 3) - 2 + height)
                {
                    tex.SetPixel(x, y, wireColor);
                }
                else if (x < (tex.width / 2) + 2 + height && y < (tex.height / 3) + 20 + height && y > (tex.height / 3) + 16 + height)
                {
                    tex.SetPixel(x, y, wireColor);
                }
                else if (x > (tex.width / 2) - 2 + height && x < (tex.width / 2) + 2 + height && y < (tex.height / 3) + 20 + height && y > (tex.height / 3) - 2 + height)
                {
                    tex.SetPixel(x, y, wireColor);
                }


            }
        }
        height = 10;
        Color wireColor2 = ColorGenerator.generatorColor();
        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                if (x > (tex.width / 2) - 2 + height && y < (tex.height / 3) + 2 + height && y > (tex.height / 3) - 2 + height)
                {
                    tex.SetPixel(x, y, wireColor2);
                }
                else if (x < (tex.width / 2) + 2 + height && y < (tex.height / 3) + 20 + height && y > (tex.height / 3) + 16 + height)
                {
                    tex.SetPixel(x, y, wireColor2);
                }
                else if (x > (tex.width / 2) - 2 + height && x < (tex.width / 2) + 2 + height && y < (tex.height / 3) + 20 + height && y > (tex.height / 3) - 2 + height)
                {
                    tex.SetPixel(x, y, wireColor2);
                }


            }
        }

        height = -10;
        Color wireColor3 = ColorGenerator.generatorColor();
        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                if (x > (tex.width / 2) - 2 + height && y < (tex.height / 3) + 2 + height && y > (tex.height / 3) - 2 + height)
                {
                    tex.SetPixel(x, y, wireColor3);
                }
                else if (x < (tex.width / 2) + 2 + height && y < (tex.height / 3) + 20 + height && y > (tex.height / 3) + 16 + height)
                {
                    tex.SetPixel(x, y, wireColor3);
                }
                else if (x > (tex.width / 2) - 2 + height && x < (tex.width / 2) + 2 + height && y < (tex.height / 3) + 20 + height && y > (tex.height / 3) - 2 + height)
                {
                    tex.SetPixel(x, y, wireColor3);
                }


            }
        }




        tex.Apply();
        Sprite outSprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        return outSprite;
    }


}
