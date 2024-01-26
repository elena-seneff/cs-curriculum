using UnityEngine;

public class Axe : MonoBehaviour
{

    private bool axe;
    // Start is called before the first frame update
    void Start()
    {
        axe = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            axe = true;
            other.gameObject.SetActive(false);
        }
    }
}
