﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

    
    public GameObject focus;

    public float health;

    public float room_level = 1;

    public float base_attack = 1;
    private float current_attack = 1;

    public float base_health = 1;
    private float current_health = 1;

    private float base_aggression_range = 10.0f;
    private float current_aggression_range = 10.0f;

    [SerializeField]
    private float base_movement_speed = 0.04f;
    [SerializeField]
    private float current_movement_speed = 0.04f;

    [SerializeField]
    private int enemy_type;

    private Rigidbody rb;

    enum ENEMY_TYPE
    {
        TYPE_1,
        TYPE_2,
        TYPE_3
    }


    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();

        enemy_type = Random.Range(0, 3);

        if (enemy_type.Equals(ENEMY_TYPE.TYPE_1))
        {
            current_health = base_health + room_level / 5;
            current_attack = base_attack + room_level;
            current_movement_speed = (Mathf.Floor((room_level) / 5) * base_movement_speed * 2 + base_movement_speed);
            current_aggression_range = (Mathf.Floor(room_level / 3) * base_aggression_range + base_aggression_range);
        }
        if (enemy_type.Equals(ENEMY_TYPE.TYPE_2))
        {
            current_health = base_health + room_level * 2;
            current_attack = base_attack + room_level * 1.25f;
            current_movement_speed = ((Mathf.Floor((room_level) / 5) * base_movement_speed / 3) + (base_movement_speed / 3));
            current_aggression_range = ((Mathf.Floor(room_level / 3) * base_aggression_range * 3) + (base_aggression_range * 3));
        }
        if (enemy_type.Equals(ENEMY_TYPE.TYPE_3))
        {
            current_health = base_health + room_level / 3;
            current_attack = base_attack + room_level;
            current_movement_speed = (Mathf.Floor((room_level) / 5) * base_movement_speed + base_movement_speed);
            current_aggression_range = (Mathf.Floor(room_level / 3) * base_aggression_range + base_aggression_range);
        }

    }
	
	// Update is called once per frame
	void Update () {

        getFocus();

        rb.velocity = new Vector3(0f, 0f, 0f);

        if (CheckPosition())
        {
            transform.position = Vector3.MoveTowards(transform.position, focus.transform.position, current_movement_speed);
            FaceObject();
        }


	}

    void FaceObject()
    {
        Vector3 direction = (focus.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    //public void Hit()
    //{

    //    if (Mathf.Sqrt(Mathf.Pow(transform.position.x - focus.transform.position.x, 2) + Mathf.Pow(transform.position.y - focus.transform.position.y, 2) + Mathf.Pow(transform.position.z - focus.transform.position.z, 2)) <= 1.2)
    //    {

    //        focus.SendMessage("TakeDamage", current_attack);
    //        Die();

    //    }

    //}

    public bool CheckPosition()
    {

        bool isClose = false;
        if (Mathf.Sqrt(Mathf.Pow(transform.position.x - focus.transform.position.x, 2) + Mathf.Pow(transform.position.y - focus.transform.position.y, 2) + Mathf.Pow(transform.position.z - focus.transform.position.z, 2)) <= current_aggression_range)
        {
            isClose = true;
        }
        return isClose;
    }

    public void Die()
    {

        Destroy(this);

    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void getFocus()
    {
        if (focus == null)
        {
            GameObject objectToFocus = GameObject.Find("Player");

            focus = objectToFocus;

        }
    }

}
