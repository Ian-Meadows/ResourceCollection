using UnityEngine;
using System.Collections;

public class GetObject : MonoBehaviour {

    public Drone drone;

    float LifeTime = 0.5f;


	// Use this for initialization
	void Start () {

        InvokeRepeating("death", LifeTime, LifeTime);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void death()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        BasicObject obj = other.GetComponent<BasicObject>();

        if (obj != null)
        {
            if (drone.searchType == Drone.SearchType.pickUp)
            {

                if (obj.GetComponent<BasicResourceNode>() != null)
                {
                    drone.pickUpIsResourceNode = true;
                    drone.pickUpIsAssemblyBuilding = false;
                }
                else if(obj.GetComponent<AssemblyBuilding>() != null)
                {
                    drone.pickUpIsResourceNode = false;
                    drone.pickUpIsAssemblyBuilding = true;
                }
                else
                {
                    drone.pickUpIsResourceNode = false;
                    drone.pickUpIsAssemblyBuilding = false;
                }

                drone.pickUp = obj;
                drone.searchType = Drone.SearchType.dropOff;
                Destroy(gameObject);
            }
            else if (drone.searchType == Drone.SearchType.dropOff && obj.GetComponent<BasicBuilding>() != null)
            {
                drone.dropOff = obj;
                drone.searchType = Drone.SearchType.none;
                Destroy(gameObject);
            }
        }
    }
}
