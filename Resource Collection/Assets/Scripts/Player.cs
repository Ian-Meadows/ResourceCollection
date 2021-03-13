using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    int speed = 15;

    Rigidbody2D rigidBody2D;

    public int money;

    public bool useStart = true;

	// Use this for initialization
	void Start () {

        if (useStart)
        {
            money = 0;
        }

        
        rigidBody2D = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        Movement();
    }

    void Movement()
    {
        int velX = 0;
        int velY = 0;

        if (Input.GetKey(KeyCode.W))
        {
            velY = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velY = -speed;
        }
        else
        {
            velY = 0;
        }


        if (Input.GetKey(KeyCode.A))
        {
            velX = -speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velX = speed;
        }
        else
        {
            velX = 0;
        }

        rigidBody2D.velocity = new Vector2(velX, velY);


    }



}
