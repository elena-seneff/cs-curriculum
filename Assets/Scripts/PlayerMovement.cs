using UnityEngine;
using Vector2 = System.Numerics.Vector2;


public class PlayerMovement : MonoBehaviour
{
    private float xspeed;
    private float xDirection;
    private float xVector;

    private float yDirection;
    private float yVector;
    
    public bool overworld;
    private float yspeed;


    private bool onGround;
    private Rigidbody2D rb2D;
    private float jumpForce;

    private bool hasaxe;
    
   
    
    // Start is called before the first frame update

    void Start()
    {
        xspeed = 4;
        
        
        if(overworld)
        {
            yspeed = 4;
        }
        else
        {
            yspeed = 0;
        }
        
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        jumpForce = 200;
    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
        xVector = xDirection * xspeed * Time.deltaTime;
        yVector = yDirection * yspeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(xVector, yVector, 0);

        if (!overworld)
        {
            if (onGround == false)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rb2D.AddForce(UnityEngine.Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }
        }
       
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        onGround = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        onGround = true; 
        if (other.gameObject.CompareTag("Cavedoor"))
        {
            if (hasaxe = true)
            {
                print("has axe and contact made");
                Destroy(other.gameObject);
            }
            
        }
    }
}
