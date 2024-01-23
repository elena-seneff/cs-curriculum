using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float xspeed;
    private float xDirection;
    private float xVector;

    private float yDirection;
    private float yVector;
    
    public bool overworld;

    private float yspeed;


    private bool onGround;
    private Rigidbody2D rb2D;
    private float jumpForce; 
   
    
    // Start is called before the first frame update

    void Start()
    {
        xspeed = 4;
        
        
        if(overworld)
        {
            yspeed = 4;
        }
        else
        {
            yspeed = 0;
        }

        onGround = false;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        jumpForce = 200;
    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
        xVector = xDirection * xspeed * Time.deltaTime;
        yVector = yDirection * yspeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(xVector, yVector, 0);

        if (!overworld)
        {
            if (onGround == false)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    
                }
            }
        }
       
    }

    private void OnColiisionExit2D(Collision2D other)
    {
        onGround = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        onGround = true;
    }
}
