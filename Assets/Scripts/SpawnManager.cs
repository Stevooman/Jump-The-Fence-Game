using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides control over the spawning of obstacles in front of the player.
/// </summary>
public class SpawnManager : MonoBehaviour
{
    public Vector3 SpawnPosition { get; private set; }
    public float StartDelay { get; private set; }
    public float RepeatRate { get; private set; }
    public string PlayerObjectName { get; private set; }
    public PlayerController PlayerControllerScript { get; private set; }


    public GameObject obstaclePrefab;

    /// <summary>
    /// Initializes the properties in this class.
    /// </summary>
    private void Awake()
    {
        SpawnPosition = new Vector3(25, 0, 0);
        StartDelay = 2;
        RepeatRate = 2;
        PlayerObjectName = "Player";
        PlayerControllerScript =
            GameObject.Find(PlayerObjectName).GetComponent<PlayerController>();
    }

    void Start()
    {
        InvokeRepeating("SpawnObstacle", StartDelay, RepeatRate);
    }

    /// <summary>
    /// Spawns the prefab obstacles in the specified spawn position.
    /// </summary>
    private void SpawnObstacle()
    {
        if (PlayerControllerScript.GameOver == false)
            Instantiate(obstaclePrefab, SpawnPosition, obstaclePrefab.transform.rotation);
    }
}
