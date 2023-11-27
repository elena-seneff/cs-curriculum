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
            ChangeHealth(amount: -1);
        }
        
        if (other.gameObject.CompareTag("Projectile"))
        {
            ChangeHealth(amount: -2);
        }

        if (other.gameObject.CompareTag("Potion"))
        {
            ChangeHealth(amount: +2);
        }
    }


    void ChangeHealth(int amount)
    {
        
       if (!iframes)
       { 
           iframes = true; 
           hud.health =+ amount;
           if (hud.health < 1)
           {
               Death();
           }
       }
       Debug.Log(message:"Health: "+hud.health);
       
    }

    private void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log(message: "You Died :( ");
    }
    
}