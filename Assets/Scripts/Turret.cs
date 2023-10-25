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
    public float launchVelocity = 10f;
    
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

    private void OnTriggerEnter(Collider other)
    {
        target = other;
    }
}
