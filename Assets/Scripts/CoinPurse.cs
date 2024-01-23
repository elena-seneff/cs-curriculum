using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CoinPurse : MonoBehaviour
{
    public HUD hud;
    
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            hud.coins++;
            other.gameObject.SetActive(false);
        }


        if (other.gameObject.CompareTag("Potion"))
        {
            if (hud.health <=3)
            {
                hud.health = hud.health + 2;
                other.gameObject.SetActive(false);
            }

            if ((hud.health == 4))
            {
                hud.health = hud.maxhealth;
                other.gameObject.SetActive(false);
            }
            
        }
    }
}

