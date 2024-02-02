using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;


public class Turret : MonoBehaviour
{
    public GameObject fireball;
    private float shootCooldown;
    public float cooldown;
    private Transform target;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        target = null;
        speed = 8;
    }

    // Update is called once per frame
    void Update()
    {
        shootCooldown -= Time.deltaTime;
        
        if (shootCooldown <= 0)
        {
            if (target != null)
            {
                print("shoot");
                GameObject clone;
                clone = Instantiate(fireball, transform.position + new Vector3(0,0,.5f), transform.rotation);

                shootCooldown = cooldown;
            }
            
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = other.gameObject.transform;
            print("got target");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        print("target gone");
        target = null;
    }
}
