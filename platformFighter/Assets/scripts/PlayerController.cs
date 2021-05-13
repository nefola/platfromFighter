using UnityEngine;

// player controller currently based off of tutorial 
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moves to the left
        if (Input.GetKey(KeyCode.K))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
                
        }
        //moves to the right
        if (Input.GetKey(KeyCode.Semicolon))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            
        }
        // jump code
        if(Input.GetKeyDown(KeyCode.C))
        {
            rb.velocity = new Vector2(rb.velocity.x, 15f);
        }

    }
}
