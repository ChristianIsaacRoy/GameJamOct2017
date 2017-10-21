using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {


    public GameObject focus;
    float speed = 0.01f;
    public float radius = 5.0f;


    // Use this for initialization
    void Start () {


	}
	
	// Update is called once per frame
	void Update () {

        getFocus();

        if (CheckPosition())
        {
            transform.position = Vector3.MoveTowards(transform.position, focus.transform.position, speed);
            FaceObject();
        }
        Hit();


	}

    void FaceObject()
    {
        Vector3 direction = (focus.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void Hit()
    {

        if (Mathf.Sqrt(Mathf.Pow(transform.position.x - focus.transform.position.x, 2) + Mathf.Pow(transform.position.y - focus.transform.position.y, 2) + Mathf.Pow(transform.position.z - focus.transform.position.z, 2)) <= 1.2)
        {
            gameObject.SendMessage("TakeDamage");
            //Die();

        }

    }

    public bool CheckPosition()
    {

        bool isClose = false;
        if(Mathf.Sqrt(Mathf.Pow(transform.position.x - focus.transform.position.x, 2) + Mathf.Pow(transform.position.y - focus.transform.position.y, 2) + Mathf.Pow(transform.position.z - focus.transform.position.z, 2)) <= radius)
        {
            isClose = true;
        }
        return isClose;
    }

    public void Die()
    {

        

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
