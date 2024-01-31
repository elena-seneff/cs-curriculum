using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject fire;
    public float speed;
    public HUD hud;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(fire ,transform.position, transform.rotation);
            
        }

       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Cavedoor"))
        {
            if (hud.hasaxe = true)
            {
                SceneManager.LoadScene("Platformer");
            }
        }
            
        
    }
    
}

