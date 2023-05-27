using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandVine : MonoBehaviour
{

    public Transform player;

    private void Start()
    {
        // Calculate the direction from the line's position to the player's position and invert it
        Vector3 direction = transform.position - player.position;

        // Create a rotation based on the inverted direction vector
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        // Set the line's rotation
        transform.rotation = rotation;
    }
}
