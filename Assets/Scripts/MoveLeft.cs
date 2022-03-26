using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public string PlayerObjectName { get; private set; }
    public float Speed { get; private set; }
    public float LeftBoundary { get; private set; }
    public string ObstacleTag { get; private set; }

    public PlayerController PlayerControllerScript { get; private set; }

    private void Awake()
    {
        PlayerObjectName = "Player";
        Speed = 30;
        LeftBoundary = -15;
        ObstacleTag = "Obstacle";
        PlayerControllerScript =
            GameObject.Find(PlayerObjectName).GetComponent<PlayerController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (PlayerControllerScript.GameOver == false)
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        if (transform.position.x < LeftBoundary && gameObject.CompareTag(ObstacleTag))
            Destroy(gameObject);
    }
}
