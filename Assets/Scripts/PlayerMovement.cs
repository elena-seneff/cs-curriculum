using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    private float xspeed;
    private float xDirection;
    private float xVector;

    private float yDirection;
    private float yVector;
    
    public bool overworld;
    private float yspeed;

    
    private Rigidbody2D rb2D;
    private float jumpForce;

    private bool onGround;
    public float raylength;
   
    
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
        jumpForce = 8;
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
            onGround = Physics2D.Raycast(transform.position, Vector2.down, raylength);
            
            if (Input.GetKeyDown(KeyCode.W) && onGround || Input.GetKeyDown(KeyCode.UpArrow) && onGround)
            {
                rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

    }


  

}
