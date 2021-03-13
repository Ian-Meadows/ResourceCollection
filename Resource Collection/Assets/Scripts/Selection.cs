using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour {

    public Drone drone;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!drone.isSelected)
        {
            Destroy(gameObject);
        }
        
	}
}
