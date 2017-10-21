using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerStats stats;
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
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.forward * Time.deltaTime * stats.speed;
        if (Input.GetKey(KeyCode.S))
            transform.position += Vector3.back * Time.deltaTime * stats.speed;
        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * Time.deltaTime * stats.speed;
        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * Time.deltaTime * stats.speed;
    }

    private void Attack()
    {
        Debug.Log("Player Has Attacked!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Has Occured!");
        //if(collision.GetType() = Enemy)
        //{
            
        //}
    }



}
