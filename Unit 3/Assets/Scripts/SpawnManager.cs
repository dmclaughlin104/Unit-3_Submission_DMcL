using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //variables
    public GameObject obstaclePrefab;
    private PlayerController playerControllerScript;
    private Vector3 spawnPosition = new Vector3(25,0,0);

    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;



    // Start is called before the first frame update
    void Start()
    {
        //spawns obstacles after start, with delay and interval
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        //assigns our player controller script within this script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }


    //spawns obstacles until Game Over
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }


    }

}
