using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script spawns objects
// Attach this script to the SpawnManager object
// This script requires an obstacle prefab to spawn
public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab; // Reference to the obstacle prefab
    public float startDelay = 2f; // Delay before spawning the first obstacle
    public float repeatRate = 2f; // Delay between spawning obstacles
    private PlayerController playerControllerScript; // This is the player controller script

    private Vector3 spawnPos = new Vector3(25, 0, 0); // Position to spawn the obstacle

    // Start is called before the first frame update
    void Start()
    {
        // Get the player controller script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        // Invoke the SpawnObstacle() method repeatedly
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Spawn an obstacle
    void SpawnObstacle()
    {
        // If the game is not over, spawn an obstacle
        if (playerControllerScript.gameOver == false)
        {
            // Instantiate the obstacle at the spawn position
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
