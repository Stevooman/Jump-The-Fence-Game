using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the position reset of the background.
/// </summary>
public class RepeatBackground : MonoBehaviour
{
    public float MoveDistance { get; private set; }
    public Vector3 StartPosition { get; private set; }

    /// <summary>
    /// Finds the exact half length of the x-axis of the background.
    /// </summary>
    void Start()
    {
        StartPosition = transform.position;
        // Get the exact halfway point of the background
        MoveDistance = GetComponent<BoxCollider>().size.x / 2;
    }

    /// <summary>
    /// Resets the position of the background to the start once it moves
    /// exactly half its length in the x direction.
    /// </summary>
    void Update()
    {
        if (transform.position.x < StartPosition.x - MoveDistance)
            transform.position = StartPosition;
    }
}
