using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField]
    private uint defense;
    [SerializeField]
    private uint candyCapacity;
    [SerializeField]
    private uint maxDefense;
    [SerializeField]
    private uint maxSpeed;
    [SerializeField]
    private uint maxCandyCapacity;
    public uint speed { get; private set; }
    private uint candyAmt;

	// Use this for initialization
	void Start ()
    {
        speed = 5;
        candyAmt = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void Die()
    {
        //Call GameManager object that kills the player
    }
    public void UpgradeSpeed(uint increaseAmt)
    {
        if (speed + increaseAmt >= maxSpeed)
            speed = maxSpeed;
        else
            speed += increaseAmt;
    }
    public void UpgradeDefense(uint increaseAmt)
    {
        if (defense + increaseAmt >= maxDefense)
            defense = maxDefense;
        else
            defense += increaseAmt;   
    }
    public void UpgradeCandyCapacity(uint increaseAmt)
    {
        if (candyCapacity + increaseAmt >= maxCandyCapacity)
            candyCapacity = maxCandyCapacity;
        else
            candyCapacity += increaseAmt;
    }

    public void TakeDamage(uint DamageAmt)
    {
        candyAmt -= DamageAmt;
        //Spawn Candy
    }
    public void AddCandy()
    {
        
    }

}
