using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    bool iframes=false;
    private float timer;
    float originalTimer;
    private float xVector;
    private float yVector;
    public HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        originalTimer = 1.5f;
        timer = originalTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (iframes)
        {
            timer -= Time.deltaTime;
            
            if (timer < 0) ;
            {
                iframes = false;
                timer = originalTimer;
            }
        }

       
        
        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            //change (amount:__) to change how much health drops by when you hit a spike
            ChangeHealth(-1);
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other. gameObject.CompareTag("Potion"))
        {
            ChangeHealth(1);
            
            if (hud.health > 5)
            {
                hud.health = 5;
            }
        }
    }


    void ChangeHealth(int amount)
   {
       if (!iframes)
       { 
           iframes = true; 
           hud.health += amount;
           if (hud.health < 1)
           {
               Death();
           }
       }
       Debug.Log("Health: "+hud.health);
    }

   void Death()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       print("You Died");

   }
   
}