using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //variables
    private float speed = 10.0f;

    private PlayerController playerControllerScript;

    private float leftBound = -7.0f;


    // Start is called before the first frame update
    void Start()
    {
        //assign player
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        //moves obstacles to left of screen until Game Over
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        //removes obstacles once they disappear offscreen
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }


        
    }
}
