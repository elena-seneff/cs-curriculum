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
    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
        xVector = xDirection * xspeed * Time.deltaTime;
        yVector = yDirection * yspeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(xVector, yVector, 0);
      
    }
    
    

   
}
