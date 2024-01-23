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
            hud.health = hud.health - 1;
            Hurt();
        }

        if (other.gameObject.CompareTag("Projectile"))
        {
            hud.health = hud.health - 2;
            Hurt();
        }
    }


    private void Hurt()
    {
        
       if (!iframes)
       { 
           iframes = true; 
           if (hud.health <= 0)
           {
               Death();
           }
       }
       Debug.Log(message:"Health: "+hud.health);
       
    }

    private void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("You Died");
    }
    
}