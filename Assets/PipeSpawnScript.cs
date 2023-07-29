using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    // Reference to Pipe prefab
    public GameObject pipe;

    public PlayerScript playerScript;

    // Seconds interval between spawning pipes
    public float spawnIntervalSeconds = 2;

    // Timer for spawning pipes
    private float timerSeconds = 0;

    public float heightOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.alive)
        {
            if (timerSeconds < spawnIntervalSeconds)
            {
                timerSeconds += Time.deltaTime;
            }
            else
            {
                spawnPipe();
                timerSeconds = 0;
            }
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Instantiate a pipe prefab at the spawner's position and rotation
        Instantiate(
            pipe,
            new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0),
            transform.rotation
        );
    }
}
