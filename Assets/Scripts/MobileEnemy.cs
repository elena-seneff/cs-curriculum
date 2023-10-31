using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MobileEnemy : MonoBehaviour
{
    private GameObject player;
    public float speed;

    private Vector3 target; 
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        player = null;
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3.MoveTowards(transform.position, target , speed * Time.deltaTime);
        }
        
    }
}