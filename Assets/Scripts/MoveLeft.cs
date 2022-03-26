using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides control over the background and obstacle movements.
/// </summary>
public class MoveLeft : MonoBehaviour
{
    public string PlayerObjectName { get; private set; }
    public float Speed { get; private set; }
    public float LeftBoundary { get; private set; }
    public string ObstacleTag { get; private set; }

    public PlayerController PlayerControllerScript { get; private set; }

    /// <summary>
    /// Initializes the properties of this class.
    /// </summary>
    private void Awake()
    {
        PlayerObjectName = "Player";
        Speed = 30;
        LeftBoundary = -15;
        ObstacleTag = "Obstacle";
        PlayerControllerScript =
            GameObject.Find(PlayerObjectName).GetComponent<PlayerController>();
    }

    /// <summary>
    /// Moves the background and obstacle through space and destroys the obstacle
    /// when it leaves the screen.
    /// </summary>
    void Update()
    {
        if (PlayerControllerScript.GameOver == false)
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        if (transform.position.x < LeftBoundary && gameObject.CompareTag(ObstacleTag))
            Destroy(gameObject);
    }
}
