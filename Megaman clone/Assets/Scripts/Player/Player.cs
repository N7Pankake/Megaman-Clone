using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    public static Player MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    //(Animations, Rigid Body, etc)
    [SerializeField]
    private Rigidbody2D myRigidBody2D;

    // Movement
    [SerializeField]
    private float maxSpeed = 3;

    [SerializeField]
    private float speed = 50f;

    [SerializeField]
    private float jumpPower = 250;

    //Conditions (Ground, can jump)
    private bool isGrounded;
    public bool MyGround
    {
        get
        {
            return isGrounded;
        }

        set
        {
            isGrounded = value;
        }
    }

    private bool canDoubleJump;
    public bool MyJump
    {
        get
        {
            return canDoubleJump;
        }

        set
        {
            canDoubleJump = value;
        }
    }

    void Update()
    {

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //Jump.
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                myRigidBody2D.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, 0);
                    myRigidBody2D.AddForce(Vector2.up * jumpPower / 1.75f);
                }
            }

        }
    }

    void FixedUpdate()
    {
        Vector3 easeVelocity = myRigidBody2D.velocity;
        easeVelocity.y = myRigidBody2D.velocity.y;
        easeVelocity.z = 0f;
        easeVelocity.x *= 0.75f;

        //Fake friction
        if (isGrounded)
        {
            myRigidBody2D.velocity = easeVelocity;
        }

        float moveX = Input.GetAxis("Horizontal");

        //Movement
        myRigidBody2D.AddForce((Vector2.right * speed) * moveX);
        if (myRigidBody2D.velocity.x > maxSpeed)
        {
            myRigidBody2D.velocity = new Vector2(maxSpeed, myRigidBody2D.velocity.y);
        }

        if (myRigidBody2D.velocity.x < -maxSpeed)
        {
            myRigidBody2D.velocity = new Vector2(-maxSpeed, myRigidBody2D.velocity.y);
        }
    }
}
