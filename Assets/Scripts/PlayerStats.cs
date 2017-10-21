using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Rigidbody bag;
    private bool bagIsRight;
    public bool rotateBag;
    public Text amtCandyText;
    public Text amtCandyCapacityText;
    public float speed { get; private set; }
    public bool canMove = true;
    private float candyAmt = 1;
    private bool isKnockedBack = false;
    public bool isInvincible = false;
    private Rigidbody rb;
    private float invincibilityTimer;
    [SerializeField]
    private float defense;
    [SerializeField]
    private float candyCapacity;
    [SerializeField]
    private float maxDefense;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float maxCandyCapacity;
    [SerializeField]
    private float knockBackDistance;
    [SerializeField]
    private float timeKnocked = 0.5f;
    [SerializeField]
    private float timeInvincible = 1f;
    [SerializeField]
    private float initialKnockbackVelocity;
    [SerializeField]
    private float bagAngularVelocity = 270;
    [SerializeField]
    public float damage;
    [SerializeField]
    private float baseDamage;

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
        bagIsRight = false;
        baseDamage = 10;
	}
	
	// Update is called once per frame
	void Update ()
    {
        amtCandyText.text = candyAmt.ToString();
        amtCandyCapacityText.text = candyCapacity.ToString();
        KnockedBack();
        TestInvincibility();
        RotateBag();
        bag.velocity = rb.velocity;
        damage = baseDamage * (candyAmt);
    }

    private void Die()
    {
        //Call GameManager object that kills the player
    }
    public void UpgradeSpeed(float increaseAmt)
    {
        if (speed + increaseAmt >= maxSpeed)
            speed = maxSpeed;
        else
            speed += increaseAmt;
    }
    public void UpgradeDefense(float increaseAmt)
    {
        if (defense + increaseAmt >= maxDefense)
            defense = maxDefense;
        else
            defense += increaseAmt;   
    }
    public void UpgradeCandyCapacity(float increaseAmt)
    {
        if (candyCapacity + increaseAmt >= maxCandyCapacity)
            candyCapacity = maxCandyCapacity;
        else
            candyCapacity += increaseAmt;
    }

    public void TakeDamage(float damageAmt)
    {
        if (!isInvincible)
        {
            candyAmt -= damageAmt + defense;
            //Spawn Candy
        }
    }
    public void AddCandy(float addedCandy)
    {
        candyAmt += addedCandy;
    }

    public void MoveForward()
    {
        //transform.position += Vector3.forward * Time.deltaTime * speed;
        rb.velocity = speed * Vector3.forward;
        bag.velocity = rb.velocity;
    }
    public void MoveBack()
    {
        //transform.position += Vector3.back * Time.deltaTime * speed;
        rb.velocity = speed * Vector3.back;
        bag.velocity = rb.velocity;
    }
    public void MoveLeft()
    {
        //transform.position += Vector3.left * Time.deltaTime * speed;
        rb.velocity = speed * Vector3.left;
        bag.velocity = rb.velocity;
    }
    public void MoveRight()
    {
        //transform.position += Vector3.right * Time.deltaTime * speed;
        rb.velocity = speed * Vector3.right;
        bag.velocity = rb.velocity;
    }
    public void NotMoving()
    {
        rb.velocity = new Vector3(0f, 0f, 0f);
    }

    public void Move()
    {

        rb.velocity = new Vector3(speed * Input.GetAxis("Horizontal"), 0, speed * Input.GetAxis("Vertical"));
        //rb.position += rb.velocity;
    }

    public void setKnockedBack(bool b, Vector3 unitDirection)
    {
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
            if (knockedTimer < 0)
            {
                setKnockedBack(false, new Vector3(0f, 0f, 0f));
            }
        }
    }
    public void setInvincibility(bool b)
    {
        if (b)
        {
            isInvincible = true;
            invincibilityTimer = timeInvincible;
        }
        else
        {
            isInvincible = false;
        }
    }

    private void TestInvincibility()
    {
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if(invincibilityTimer < 0)
            {
                isInvincible = false;
            }
        }
    }

    private void RotateBag()
    {
        if(rotateBag)
        {
            float angle = bag.transform.rotation.eulerAngles.y;
            if (angle > 180)
            {
                angle = angle - 360;
            }
            if (bagIsRight)
            {
                bag.transform.RotateAround(this.transform.position, Vector3.up, -bagAngularVelocity * Time.deltaTime);
                
                if (angle < -45f)
                {
                    bag.transform.RotateAround(this.transform.position, Vector3.up, -45 - angle);
                    bagIsRight = false;
                    rotateBag = false;
                }
            } else
            {
                bag.transform.RotateAround(this.transform.position, Vector3.up, bagAngularVelocity * Time.deltaTime);
                Debug.Log(angle);
                if (angle > 45f)
                {
                    bag.transform.RotateAround(this.transform.position, Vector3.up, 45 - angle);
                    bagIsRight = true;
                    rotateBag = false;
                }
            }
        }
    }
}
