using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField]
    private float amtOfCandy;
    private PlayerStats player;
    private bool canPickup = false;
    

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>();
    }
    public void SetCanPickup()
    {
        canPickup = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && canPickup)
        {
            player.AddCandy(amtOfCandy);
            Destroy(this.gameObject);
        }
    }

}
