using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerManger : MonoBehaviour
{
    public PlayerController playerController;
    public Transform transfrom;
    private Rigidbody2D rb;
    private Collider2D coll;
    public bool amLeft = false;
    public bool amRight = true;
    public bool amGrounded = true;
    public bool hasAirJumps;
    bool amJumping;
    public int airJumps = 3;
    [SerializeField] private LayerMask platfrom; //done for more efficent processing
    //private enum status {worda, wordb, wordc};
    //possible way of loging status more effectivly 
  
    // Start is called before the first frame update
    void Start()
    {
        // lets us import from a PlayerController
        playerController = GetComponent<PlayerController>();
        coll = GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //importing direction from playerControler
        amLeft = playerController.beLeft;
        amRight = playerController.beRight;
        amJumping = playerController.tryJumping;
        //float hDir = Input.GetAxis("Horizontal");
        //used for unity side controls

        if (coll.IsTouchingLayers(platfrom))      // the platform layer
        {
            amGrounded = true;
        }   
        else
        {
            amGrounded = false;
        }
        print(amGrounded); //debug line
        // why the fuck am i not grounded

        if (amLeft == true)
        {
            transform.localScale = new Vector2 (-1, 1);
        }
        if(amRight == true)
        {
            transform.localScale = new Vector2(1, 1);
        }
        //refreshes jumps on ground, subject to change
        if(amGrounded == true)
        {
            airJumps = 3;
        }
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


    }
}