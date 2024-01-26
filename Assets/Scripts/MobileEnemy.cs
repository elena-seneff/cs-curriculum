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
    public GameObject Axe;
    public bool axeenemy;
    private bool hasaxe;
    
    void Start()
    {
        enemyhealth = 2;
    }

    void Update()
    {
        if (enemyhealth <= 0)
        {
            enemydrop = Random.Range(0, 3);

            if (enemydrop == 1)
            {
                Destroy(gameObject);
                Instantiate(Potion, transform.position, transform.rotation);
                print("dropped potion");
            }

       

            if (enemydrop == 2)
            {
                Destroy(gameObject);
                Instantiate(Coin, transform.position, transform.rotation);
                print("dropped coin");
            }

            if (enemydrop == 3)
            {
                Destroy(gameObject);
                print("no drop");
            }

            if (axeenemy == true)
            {
                Destroy(gameObject);
                Instantiate(Axe, transform.position, transform.rotation);
                print("dropped axe");
                hasaxe = true;
            }
        }

        if (hasaxe = true)
        {
            print("has axe");
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

    
}


