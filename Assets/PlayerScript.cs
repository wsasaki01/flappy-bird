using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Reference to player's RB2D
    public Rigidbody2D myRigidbody;

    public CircleCollider2D myCollider;

    public AudioSource audioSource;

    public AudioClip flapSound;
    public AudioClip dieSound;

    public float flapStrength;

    public LogicScript logic;

    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        // See PipeMiddleScript for details
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && alive)
        {
            // Vector2.up is shorthand for new Vector2(0,1)
            // multilied by 10 to make it go further up
            myRigidbody.velocity = Vector2.up * flapStrength;

            audioSource.clip = flapSound;
            audioSource.Play();
        }
    }

    // Note that this is Collision, not Trigger
    // The pipes are normal colliders, not triggers, so they need this method instead
    private void OnCollisionEnter2D(Collision2D collision)
    {
        alive = false;

        audioSource.clip = dieSound;
        audioSource.Play();

        myCollider.enabled = false;

        myRigidbody.velocity = new Vector3(-5, 5, 0);
        myRigidbody.angularVelocity = UnityEngine.Random.Range(-100f, 100f);

        logic.gameOver();
    }
}
