using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField]
    private float amtOfCandy;
    [SerializeField]
    private PlayerStats player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.AddCandy(amtOfCandy);
        }
        Destroy(this);
    }

}
