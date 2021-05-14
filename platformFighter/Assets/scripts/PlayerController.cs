using UnityEngine;

// player controller currently based off of tutorial 
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public PlayerManger playerManger;

    public bool beLeft;
    public bool beRight;
    bool hasAirJumps;
    bool amGrounded;
    public bool tryJumping = false;
    public float speed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerManger = GetComponent<PlayerManger>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //getting info from player manger
        hasAirJumps = playerManger.hasAirJumps;
        amGrounded = playerManger.amGrounded;
        //moves to the left
        if (Input.GetKey(KeyCode.L))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            beLeft = true;
            beRight = false;
        }
        //moves to the right
        if (Input.GetKey(KeyCode.Quote))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            beRight = true;
            beLeft = false;
            
        }
        // jump code
        if (Input.GetKeyDown(KeyCode.C) && (amGrounded || hasAirJumps))
        {
            rb.velocity = new Vector2(rb.velocity.x, 15f);
            tryJumping = true;
        }  else
        {
            tryJumping = false;
        }

        print(rb.velocity);
        // debug to check speed
    }
}
