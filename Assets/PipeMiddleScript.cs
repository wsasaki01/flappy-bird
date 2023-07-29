using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        // Once a pipe prefab spawns...
        // Look through the list of objects with the "Logic" tag...
        // And pick the first one
        // Make a reference to its LogicScript
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check that the player, not some other object, went through
        if (collision.gameObject.layer == 3)
        {
            logic.AddScore(1);
        }
    }
}
