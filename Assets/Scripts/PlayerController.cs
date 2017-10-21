using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerStats player;
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
	}

    private void Move()
    {
        if (player.canMove)
        {
            if (Input.GetKey(KeyCode.W))
                player.MoveForward();
            if (Input.GetKey(KeyCode.S))
                player.MoveBack();
            if (Input.GetKey(KeyCode.A))
                player.MoveLeft();
            if (Input.GetKey(KeyCode.D))
                player.MoveRight();
        }
    }
}
