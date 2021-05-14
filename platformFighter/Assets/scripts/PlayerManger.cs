using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerManger : MonoBehaviour
{
    public PlayerController playerController;
    public Transform transfrom;

    public bool amLeft = false;
    public bool amRight = true;
    public bool amGrounded = true;
  
    // Start is called before the first frame update
    void Start()
    {
        // lets us import from a PlayerController
        playerController = GetComponent<PlayerController>(); 
    }

    void LateUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //importing direction from playerControler
        amLeft = playerController.beLeft;
        amRight = playerController.beRight;

        if(amLeft == true)
        {
            transform.localScale = new Vector2 (-1, 1);
        }
        if(amRight == true)
        {
            transform.localScale = new Vector2(1, 1);
        }

    }
}
