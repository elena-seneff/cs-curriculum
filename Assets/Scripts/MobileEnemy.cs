using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


public class MobileEnemy : MonoBehaviour
{
    private float enemyhealth;
    private float enemydrop;
    public GameObject Potion;
    public GameObject Coin;
    
    void Start()
    {
        enemyhealth = 2;
    }

    void Update()
    {
        if (enemyhealth <= 0)
        {
            enemydrop = Random.Range(0, 100);

            if (enemydrop <= 25)
            {
                Destroy(gameObject);
                Instantiate(Potion, transform.position, transform.rotation);
                print("dropped potion");
            }

       

            if (enemydrop <=50 && enemydrop > 25)
            {
                Destroy(gameObject);
                Instantiate(Coin, transform.position, transform.rotation);
                print("dropped coin");
            }

            if (enemydrop <=100 && enemydrop > 50)
            {
                Destroy(gameObject);
                print("no drop");
            }


        }
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyhealth -= 1;
            print("Hit");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
        
        
    }
}


