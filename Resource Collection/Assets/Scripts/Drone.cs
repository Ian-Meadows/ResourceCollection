using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour {

    int speed = 10;

    public BasicObject pickUp;
    public BasicObject dropOff;

    public bool pickUpIsResourceNode = false;
    public bool pickUpIsAssemblyBuilding = false;

    public bool isSelected = false;

    public bool hasItem = false;

    public enum SearchType {pickUp, dropOff, none};
    public SearchType searchType = new SearchType();

    public GetObject getObjectPrefab;
    public Selection selectionPrefab;
    bool hasSpawnedSelection;

    public Item item;

    bool checkNext = false;

    public ItemImage itemImagePrefab;

    GameController gameController;

    public bool useStart = true;

    // Use this for initialization
    void Start () {

        if (useStart)
        {
            item = null;

            hasItem = false;

            pickUpIsResourceNode = false;
            pickUpIsAssemblyBuilding = false;
        }

        
        isSelected = false;
        searchType = SearchType.none;

        gameController = FindObjectOfType<GameController>();

        ItemImage newItemImage = Instantiate(itemImagePrefab);
        newItemImage.transform.SetParent(transform);
        newItemImage.drone = this;
        newItemImage.showsDrone = true;
        newItemImage.transform.localPosition = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {

        if (searchType == SearchType.none)
        {
            isSelected = false;
        }
        input();
        Movement();

        checkNext = false;

        if (isSelected)
        {
            if (!hasSpawnedSelection)
            {
                hasSpawnedSelection = true;
                Selection newSelection = (Selection)Instantiate(selectionPrefab, Vector3.zero, Quaternion.identity);
                newSelection.transform.SetParent(transform);
                newSelection.transform.localPosition = Vector3.zero;
                newSelection.drone = this;
                
            }
            
        }
        else
        {
            if (hasSpawnedSelection)
            {
                hasSpawnedSelection = false;
            }
        }
        

    }
    
    void input()
    {
        if (isSelected)
        {
            if (Input.GetMouseButtonDown(1))
            {
                GetObject newGetObject = (GetObject)Instantiate(getObjectPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                newGetObject.drone = this;
            }
            if (Input.GetMouseButtonDown(0) && !checkNext)
            {
                isSelected = false;
            }
        }
    }


    void Movement()
    {
        if (pickUp != null && dropOff != null)
        {
            if (hasItem)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, dropOff.transform.position, step);
            }
            else
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, pickUp.transform.position, step);
            }
        }
    }

    void OnMouseDown()
    {
        if (gameController.mouseIsAvailible)
        {
            isSelected = true;
            searchType = SearchType.pickUp;
            checkNext = true;
        }
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (searchType == SearchType.none)
        {
            BasicObject obj = other.GetComponent<BasicObject>();

            if (obj != null)
            {
                if (hasItem)
                {
                    if (dropOff.Equals(obj))
                    {
                        hasItem = false;

                        dropOff.GetComponent<BasicBuilding>().giveItem(item);
                        item = null;
                    }
                }
                else
                {
                    if (pickUp.Equals(obj))
                    {

                        if (pickUpIsResourceNode)
                        {
                            item = pickUp.GetComponent<BasicResourceNode>().getItem();
                            hasItem = true;
                        }
                        else if (pickUpIsAssemblyBuilding)
                        {
                            item = pickUp.GetComponent<AssemblyBuilding>().RetrieveItem();
                            if (item!= null)
                            {
                                hasItem = true;
                            }
                        }

                        
                    }
                }
            }
        }
        
    }

}
