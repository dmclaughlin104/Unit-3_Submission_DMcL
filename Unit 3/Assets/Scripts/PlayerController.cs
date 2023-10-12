using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    private Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityModifier;
    private bool isOnGround = true;

    public bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        //assign rigid body component to variable
        playerRB = GetComponent<Rigidbody>();

        //apply gravity physics
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        //jump control
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround ) {

            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnGround = false;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("You've hit an obstacle - GAME OVER");
        }



    }

}
