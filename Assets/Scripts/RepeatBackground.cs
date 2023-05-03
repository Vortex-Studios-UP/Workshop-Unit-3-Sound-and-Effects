using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script moves the object to the left and resets it when it goes off screen
// Attach this script to the background object
// This script requires a BoxCollider component on the object
public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos; // Start position of the object
    private float repeatWidth; // Width of the object

    // Start is called before the first frame update
    void Start()
    {
        // Get the start position of the object
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // If the object goes off screen, reset it
        if (transform.position.x < startPos.x - repeatWidth)
            transform.position = startPos;
    }
}
