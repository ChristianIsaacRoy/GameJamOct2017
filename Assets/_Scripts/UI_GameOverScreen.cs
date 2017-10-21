using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_GameOverScreen : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        transform.DOLocalMove(Vector3.zero, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
