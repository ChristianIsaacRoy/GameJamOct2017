﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mover : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.DOMove(new Vector3(0, 0, 0), 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
