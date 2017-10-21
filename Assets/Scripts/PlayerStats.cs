using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public uint speed { get; private set; }
    public bool canMove = true;
    private uint candyAmt = 1;
    private bool isKnockedBack = false;
    private bool isInvincible = false;
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
    [SerializeField]
    private uint timeKnocked = 1;
    [SerializeField]
    private uint timeInvincible = 5;

    private uint knockedTimer;

    // Use this for initialization
    void Start ()
    {
        speed = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {
        KnockedBack();
        
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

    public void TakeDamage(uint damageAmt)
    {
        if (!isInvincible)
        {
            candyAmt -= damageAmt + defense;
            //Spawn Candy
            KnockedBack();
            GetInvincibility();
        }
    }
    public void AddCandy(uint addedCandy)
    {
        candyAmt += addedCandy;
    }

    public void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }
    public void MoveBack()
    {
        transform.position += Vector3.back * Time.deltaTime * speed;
    }
    public void MoveLeft()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
    public void MoveRight()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }

    public void setKnockedBack(bool b)
    {
        if (b)
        {
            isKnockedBack = true;
            canMove = false;
            knockedTimer = timeKnocked;
        } else
        {
            canMove = true;
            isKnockedBack = false;
        }
    }

    private void KnockedBack()
    {
        if (isKnockedBack)
        {
            // Make some knockback movement

            knockedTimer -= (uint)Time.deltaTime;
            if (knockedTimer < 0)
            {
                setKnockedBack(false);
            }
        }
    }



    private void GetInvincibility()
    {
        isInvincible = true;
        if (timeInvincible > 0)
        {
            timeInvincible -= (uint)Time.deltaTime;
        }
        else
        {
            isInvincible = false;
        }
    }
}
