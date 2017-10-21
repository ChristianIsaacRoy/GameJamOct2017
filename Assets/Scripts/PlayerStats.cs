using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float speed { get; private set; }
    public bool canMove = true;
    private uint candyAmt = 1;
    private bool isKnockedBack = false;
    private bool isInvincible = false;
    private Rigidbody rb;
    [SerializeField]
    private uint defense;
    [SerializeField]
    private uint candyCapacity;
    [SerializeField]
    private uint maxDefense;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private uint maxCandyCapacity;
    [SerializeField]
    private float knockBackDistance;
    [SerializeField]
    private float timeKnocked = 0.5f;
    [SerializeField]
    private float timeInvincible = 5f;
    [SerializeField]
    private float initialKnockbackVelocity;

    private float knockAcceleration;
    private float knockedTimer;
    private Vector3 knockedDirection;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        speed = 5;
        knockAcceleration = 2 * (knockBackDistance - initialKnockbackVelocity * timeKnocked) / (timeKnocked * timeKnocked);
        Debug.Log(knockAcceleration);
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

    public void setKnockedBack(bool b, Vector3 unitDirection)
    {
        Debug.Log(unitDirection);
        if (b)
        {
            isKnockedBack = true;
            canMove = false;
            knockedTimer = timeKnocked;
            knockedDirection = unitDirection;
            rb.velocity = initialKnockbackVelocity * unitDirection;
        } else
        {
            canMove = true;
            isKnockedBack = false;
            rb.velocity = unitDirection;
        }
    }

    private void KnockedBack()
    {
        if (isKnockedBack)
        {
            // Make some knockback movement
            rb.velocity += knockAcceleration * knockedDirection * Time.deltaTime;

            // Update Knockback Timer
            knockedTimer -= Time.deltaTime;
            Debug.Log(knockedTimer);
            if (knockedTimer < 0)
            {
                setKnockedBack(false, new Vector3(0f, 0f, 0f));
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
