using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script moves the object to the left
// Attach this script to the object
public class MoveLeft : MonoBehaviour
{
    public float speed = 15f; // Speed of the object
    private float bound = -15f; // Position to destroy the object
    private PlayerController playerControllerScript; // This is the player controller script

    // Start is called before the first frame update
    void Start()
    {
        // Get the player controller script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the game is over, stop moving the object
        if (playerControllerScript.gameOver == false)
        {
            // Move the object to the left
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // If the object's position is less than the bound, destroy the object
        if (transform.position.x < bound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
