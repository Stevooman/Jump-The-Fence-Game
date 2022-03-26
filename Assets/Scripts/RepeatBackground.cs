using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public float MoveDistance { get; private set; }

    public Vector3 StartPosition { get; private set; }

    void Start()
    {
        StartPosition = transform.position;
        // Get the exact halfway point of the background
        MoveDistance = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        if (transform.position.x < StartPosition.x - MoveDistance)
            transform.position = StartPosition;
    }
}
