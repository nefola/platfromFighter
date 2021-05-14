using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
    public PlayerController playerController;
    public Transform transfrom;
    private Rigidbody2D rb;
    private Collider2D coll;
    // things that are refenced
    public bool amLeft = false;
    public bool amRight = true;
    public bool amGrounded = true;
    public bool hasAirJumps;
    bool amJumping;
    public int airJumps = 3;
    [SerializeField] private LayerMask platfrom; //done for more efficent processing

    //status druations: keep track of frames left in an action
    public int jumpFrame;
    public int testAttckFrame;

    //end of status durations

    //private enum status {inactive, j, wordc};
    //possible way of loging status more effectivly 

    // Start is called before the first frame update
    void Start()
    {
        // lets us import from a PlayerController
        playerController = GetComponent<PlayerController>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //importing direction from playerControlerfor things outside of functions
        amJumping = playerController.tryJumping;
        //float hDir = Input.GetAxis("Horizontal");
        //used for unity side controls

        groundedCheck();      

        xDireactionManagment();

        // gravity();
        // custom gravity out of use untill grounded status is fixed and movement is transfered out of playerControler

        //refreshes jumps on ground, subject to change
        
        if(airJumps > 0)
        {
            hasAirJumps = true;
        } else
        {
            hasAirJumps = false;
        }
        if (amJumping == true)
        {
            airJumps--;
        }
        if (amGrounded == true)
        {
            airJumps = 3;
        }

        
    }
   // called functions here
    private void xDireactionManagment()
    {
        amLeft = playerController.beLeft;
        amRight = playerController.beRight;
        if (amLeft == true)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (amRight == true)
        {
            transform.localScale = new Vector2(1, 1);
        }
        //currently only changes the direction the player aprears
    }
    private void groundedCheck()
    {
        if (coll.IsTouchingLayers(platfrom))      // the platform layer
        {
            amGrounded = true;
        }
        else
        {
            amGrounded = false;
        }
        // print(amGrounded); //debug line
    }
    private void gravity()
    {
        if (amGrounded == false)
        {
            rb.velocity = new Vector2(rb.velocity.x , rb.velocity.y - 0.3f);
        }
    }
}