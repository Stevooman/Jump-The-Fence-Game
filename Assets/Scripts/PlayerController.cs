using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides control of the player and controls the movements, animations
/// and particle effects associated with the player.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public bool IsOnGround { get; set; }
    public bool GameOver { get; private set; }
    public string ObstacleTag { get; private set; }
    public string GroundTag { get; private set; }
    public string JumpTriggerName { get; private set; }
    public string DeathAnimationName { get; private set; }
    public string DeathTypeIntName { get; private set; }
    public float GravityModifier { get; private set; }
    public float JumpForce { get; private set; }
    public float SoundEffectVolume { get; private set; }
    public Rigidbody PlayerRigidBody { get; private set; }
    public Animator PlayerAnimation { get; private set; }
    public AudioSource PlayerAudio { get; private set; }

    // Variables initialized in editor
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    /// <summary>
    /// Initializes the properties of this class.
    /// </summary>
    private void Awake()
    {
        IsOnGround = true;
        GameOver = false;
        ObstacleTag = "Obstacle";
        GroundTag = "Ground";
        JumpTriggerName = "Jump_trig";
        DeathAnimationName = "Death_b";
        DeathTypeIntName = "DeathType_int";
        GravityModifier = 2.5f;
        JumpForce = 800;
        SoundEffectVolume = 0.4f;
        PlayerRigidBody = GetComponent<Rigidbody>();
        PlayerAnimation = GetComponent<Animator>();
        PlayerAudio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Adjusts the gravity in the game.
    /// </summary>
    void Start()
    {
        Physics.gravity *= GravityModifier;
    }

    /// <summary>
    /// Controls the player jump mechanic and stops the dirt animation while in the air.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !GameOver)
        {
            PlayerRigidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            PlayerAudio.PlayOneShot(jumpSound, SoundEffectVolume);
            IsOnGround = false;
            PlayerAnimation.SetTrigger(JumpTriggerName);
            dirt.Stop();
        }
            
    }

    /// <summary>
    /// Controls collision detection with the ground and obstacles.
    /// Controls sound effect and particles upon collision.
    /// </summary>
    /// <param name="collision">Collision object created when two objects collide.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GroundTag) && !GameOver)
        {
            IsOnGround = true;
            dirt.Play();
        }   
        else if (collision.gameObject.CompareTag(ObstacleTag))
        {
            GameOver = true;
            Debug.Log("Game Over");
            PlayerAnimation.SetBool(DeathAnimationName, true);
            PlayerAnimation.SetInteger(DeathTypeIntName, 1);
            PlayerAudio.PlayOneShot(crashSound, SoundEffectVolume);
            explosion.Play();
            dirt.Stop();
        }    
    }
}
