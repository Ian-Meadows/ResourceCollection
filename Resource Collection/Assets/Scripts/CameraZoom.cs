using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {


    float zoom = 20;

    Camera mainCamera;

	// Use this for initialization
	void Start () {

        mainCamera = GetComponent<Camera>();

    }
	
	// Update is called once per frame
	void Update () {
        input();
        ZoomCamera();
    }

    void input()
    {
        zoom += -Input.mouseScrollDelta.y;

        if (zoom <=0 )
        {
            zoom = 1;
        }
        else if (zoom >= 61)
        {
            zoom = 60;
        }

    }

    void ZoomCamera()
    {
        mainCamera.orthographicSize = zoom;
    }
}
