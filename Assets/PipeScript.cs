using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -20;

    public PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // only move if the player is alive
        if (playerScript.alive)
        {
            // Time.deltaTime ensures this code runs at regular intervals
            // Not necessary for velocity code in PlayerScript as physics has its own clock
            transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
        }
        

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }

        
    }
}
