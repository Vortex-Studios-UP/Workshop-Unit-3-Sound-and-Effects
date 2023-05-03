using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the player
// Attach this script to the player
// This script requires a Rigidbody, BoxCollider, Animator and AudioSource component
public class PlayerController : MonoBehaviour
{
    // Logic variables
    public float jumpForce = 10f; // This is the force that will be applied to the player when they jump
    public float gravityModifier = 2f; //  This is the modifier that will be applied to the gravity
    public bool isOnGround = true; //   This is a boolean that will be used to check if the player is on the ground
    public bool gameOver = false; // This is a boolean that will be used to check if the game is over

    // Asset variables
    public ParticleSystem explosionParticle; // This is the particle system that will be played when the player collides with an obstacle
    public ParticleSystem dirtParticle; // This is the particle system that will be played when the player is on the ground
    public AudioClip jumpSound; // This is the sound that will be played when the player jumps
    public AudioClip crashSound; // This is the sound that will be played when the player collides with an obstacle

    // Component variables
    private Animator playerAnim; // This is the player's animator
    private Rigidbody playerRb; // This is the player's rigidbody
    private AudioSource playerAudio; // This is the player's audio source


    // Start is called before the first frame update
    void Start()
    {
        // Get the player's rigidbody
        playerRb = GetComponent<Rigidbody>();
        // Get the player's Animator
        playerAnim = GetComponent<Animator>();
        // Get the player's audio source
        playerAudio = GetComponent<AudioSource>();
        // Set the gravity modifier
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player presses the space bar and is on the ground, jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            Jump();
        }
    }

    // This function will be called when the player collides with something
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ResetJump();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }
    
    // This function will be called when the player jumps
    void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        // Set isOnGround to false to prevent the player from jumping again
        isOnGround = false;
        // Play the jump animation
        playerAnim.SetTrigger("Jump_trig");
        // Stop the dirt particle system
        dirtParticle.Stop();
        // Play the jump sound
        playerAudio.PlayOneShot(jumpSound, 1.0f);
    }

    // This function will be called when the player collides with the ground
    void ResetJump()
    {
        // If the player collides with the ground, set isOnGround to true to allow the player to jump again
        isOnGround = true;
        // Play the dirt particle system
        dirtParticle.Play();
    }

    // This function will be called when the player collides with an obstacle
    void Die()
    {
        // Play the explosion particle system
        explosionParticle.Play();
        // Stop the dirt particle system
        dirtParticle.Stop();
        // Play the crash sound
        playerAudio.PlayOneShot(crashSound, 1.0f);
        
        // If the player collides with an obstacle, set gameOver to true
        gameOver = true;
        Debug.Log("Game Over!");
        
        // Play the death animation
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
    }
}
