using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;


    // Start is called before the first frame update
    void Start()
    {
        //assigning background start position to variable
        startPosition = transform.position;

        //assigning background repeatin width to variable
        repeatWidth = GetComponent<BoxCollider>().size.x/2;

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x < startPosition.x - repeatWidth) {

            transform.position = startPosition;

        
        }

    }
}
