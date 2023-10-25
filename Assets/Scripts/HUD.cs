using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class HUD : MonoBehaviour
{
    public static HUD hud;
    public int coins;
    public int health;
   
    
    public CoinPurse coinPurse;
    public HealthManager healthManager;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    
    void Awake()
    {
        if (hud != null && hud != this)
        {
            Destroy(gameObject);
        }
        else
        {
            hud = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
        healthText.text = "Health: " + health;

        coinText.text = coins.ToString();
        coinText.text = "Coins: " + coins;
    }
}
