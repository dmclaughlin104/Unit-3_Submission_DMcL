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
        isOnGround = true;
    }

}
