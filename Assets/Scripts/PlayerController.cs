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
        if (Input.GetKey(KeyCode.Space))
            Attack();

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


    private void Attack()
    {
        Debug.Log("Player Has Attacked!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Has Occured!");
        Debug.Log(collision.GetType());
        if(collision.gameObject.tag == "Enemy")
        {
<<<<<<< HEAD
            Debug.Log("The Collision is from an enemy!");
            player.setKnockedBack(true, (this.transform.position - collision.transform.position).normalized);
=======
            player.setKnockedBack(true);
            player.setInvincibility(true);
>>>>>>> 37312b7b5a01c4d7d6f0d05c1883a066f9eb60eb
        }
    }




}
