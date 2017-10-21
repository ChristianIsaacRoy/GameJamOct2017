﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagTrigger : MonoBehaviour {

    public PlayerStats player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && player.rotateBag)
        {
            other.GetComponent<Enemy>().Damage(player.damage);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && player.rotateBag)
        {
            other.GetComponent<Enemy>().Damage(player.damage);
        }
    }
}
