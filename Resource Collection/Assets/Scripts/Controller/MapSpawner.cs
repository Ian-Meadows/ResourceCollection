using UnityEngine;
using System.Collections;


public class MapSpawner : MonoBehaviour {


    int mapSizeX = 300;
    int mapSizeY = 300;

    int size = 2;

    public GameObject wallPrefab;

    public Player playerPrefab;
    public Drone dronePrefab;
    public HomeBuilding homeBuildingPrefab;
    public AssemblyBuilding assemblyBuildingPrefab;

    public BasicResourceNode CopperPrefab;
    public BasicResourceNode GoldPrefab;
    public BasicResourceNode IronPrefab;
    public BasicResourceNode CoalPrefab;

    public int seed = 0;

    System.Random random;
    Load load;

    DroneSave[] droneSaves;
    AssemblySave[] assemblySaves;

    // Use this for initialization
    void Start () {
        load = FindObjectOfType<Load>();

        if (!load.newSave)
        {
            seed = load.savedClass.seed;
        }
        else
        {
            seed = Random.Range(0, 10000000);
        }

        random = new System.Random(seed);

        droneSaves = load.savedClass.droneSaves;
        assemblySaves = load.savedClass.assemblySaves;

        SpawnMap();

        FindObjectOfType<GameController>().mapSeed = seed;


        Destroy(gameObject);


    }
	
	// Update is called once per frame
	void Update () {
	
	}


    void SpawnMap()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                if (x == 0)
                {
                    spawnWall(x, y);
                }
                else if (y == 0)
                {
                    spawnWall(x, y);
                }
                else if (x == mapSizeX - 1)
                {
                    spawnWall(x, y);
                }
                else if (y == mapSizeY - 1)
                {
                    spawnWall(x, y);
                }
                else if (x > (mapSizeX / 2) + 10 || y > (mapSizeY / 2) + 10 || y < (mapSizeY / 2) - 10 || x < (mapSizeX / 2) - 10)
                {
                    if (random.NextDouble() < 0.006)
                    {
                        if (random.NextDouble() < 0.4)
                        {
                            spawnResource(x, y, IronPrefab);
                        }
                        else if (random.NextDouble() < 0.8)
                        {
                            spawnResource(x, y, CopperPrefab);
                        }
                        else
                        {
                            spawnResource(x, y, CoalPrefab);
                        }
                    }
                    else if (x < mapSizeX / 4 || y < mapSizeY / 4 || y > mapSizeY - mapSizeY / 4 || x > mapSizeX - mapSizeX / 4)
                    {
                        if (random.NextDouble() < 0.001)
                        {
                            spawnResource(x, y, GoldPrefab);
                        }
                    }
                }
                


            }
        }


        
        
        Instantiate(homeBuildingPrefab, new Vector3(mapSizeX, mapSizeY, 0), Quaternion.identity);
        if (load.newSave)
        {
            Instantiate(playerPrefab, new Vector3(mapSizeX, mapSizeY + 10, 0), Quaternion.identity);
            Instantiate(dronePrefab, new Vector3(mapSizeX - 5, mapSizeY + 10, 0), Quaternion.identity);
            Instantiate(assemblyBuildingPrefab, new Vector3(mapSizeX + 10, mapSizeY + 10, 0), Quaternion.identity);
        }
        else
        {

            Player newPlayer = (Player)Instantiate(playerPrefab, new Vector3(load.savedClass.playerX, load.savedClass.playerY, 0), Quaternion.identity);
            newPlayer.money = load.savedClass.money;
            newPlayer.useStart = false;
            for (int i = 0; i < assemblySaves.Length; i++)
            {
                spawnAssembly(assemblySaves[i]);
            }

            for (int i = 0; i < droneSaves.Length; i++)
            {
                spawnDrone(droneSaves[i]);
            }
        }
        

    }

    void spawnWall(int x, int y)
    {
        Instantiate(wallPrefab, new Vector3(x * size, y * size, 0), Quaternion.identity);
    }

    void spawnResource(int x, int y, BasicResourceNode prefab)
    {
        Instantiate(prefab, new Vector3(x * size, y * size, 0), Quaternion.identity);
    }

    void spawnAssembly(AssemblySave save)
    {
        AssemblyBuilding newBuilding = (AssemblyBuilding)Instantiate(assemblyBuildingPrefab, new Vector3(save.x, save.y, 0), Quaternion.identity);
        newBuilding.recipe = save.recipe;
        newBuilding.amounts = save.amounts;
        newBuilding.endItemTotal = save.endAmount;
        newBuilding.useStart = false;


    }

    void spawnDrone(DroneSave save)
    {
        Drone newDrone = (Drone)Instantiate(dronePrefab, new Vector3(save.x, save.y, -1), Quaternion.identity);
        newDrone.item = save.item;
        newDrone.pickUpIsResourceNode = save.pickUpIsResource;
        newDrone.pickUpIsAssemblyBuilding = save.pickUpIsAssembly;
        newDrone.hasItem = save.hasItem;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(new Vector2(save.pickUpX, save.pickUpY), 0.2f);


        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].GetComponent<BasicObject>() != null)
            {
                newDrone.pickUp = hitColliders[i].GetComponent<BasicObject>();
            }
        }




        hitColliders = Physics2D.OverlapCircleAll(new Vector2(save.dropOffX, save.dropOffY), 0.2f);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].GetComponent<BasicObject>() != null)
            {
                newDrone.dropOff = hitColliders[i].GetComponent<BasicObject>();
            }
        }

        newDrone.useStart = false;

    }

}
