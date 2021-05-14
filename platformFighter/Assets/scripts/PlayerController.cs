using UnityEngine;

// player controller currently based off of tutorial 
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool beLeft;
    public bool beRight;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //moves to the left
        if (Input.GetKey(KeyCode.L))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            beLeft = true;
            beRight = false;
        }
        //moves to the right
        if (Input.GetKey(KeyCode.Quote))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            beRight = true;
            beLeft = false;
        }
        // jump code
        if(Input.GetKeyDown(KeyCode.C))
        {
            rb.velocity = new Vector2(rb.velocity.x, 15f);
        }

    }
}
