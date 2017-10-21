using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerStats player;
    public float rotationSpeed;

	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        if (Input.GetKey(KeyCode.Mouse0))
            Attack();

        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        //Quaternion lookRotation = Quaternion.LookRotation(Camera.main.ScreenToWorldPoint(new Vector3((float) direction.z, 0f, (float) direction.x)));
        //player.transform.rotation = lookRotation;
    }

    private void Move()
    {
        if (player.canMove)
        {
            player.Move();
        }
    }


    private void Attack()
    {
        Debug.Log("Player Has Attacked!");
        player.rotateBag = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Has Occured!");
        Debug.Log(collision.GetType());
        if(collision.gameObject.tag == "Enemy" && !player.isInvincible)
        {
            Debug.Log("The Collision is from an enemy!");
            player.TakeDamage(collision.gameObject.GetComponent<Enemy>().atkDamage);
            player.setKnockedBack(true, (this.transform.position - collision.transform.position).normalized);
            player.setInvincibility(true);
        }
        if(collision.gameObject.tag == "Door")
        {
            player.setKnockedBack(true, (this.transform.position - collision.transform.position).normalized);
        }
    }




}
