using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;


public class Turret : MonoBehaviour
{
    
    private float originalTimer;
    private float timer;
    public GameObject Turret_Projectile;
    private GameObject target;
    
    
    // Start is called before the first frame update
    void Start()
    {
        originalTimer = 1.5f;
        timer = originalTimer;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            timer -= Time.deltaTime;
            
            if (timer < 0)
            {
                Instantiate(Turret_Projectile, transform.position, transform.rotation);
                timer = originalTimer;
            }
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        target = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        target = null;
    }
}
