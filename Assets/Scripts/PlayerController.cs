using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody>();
        PlayerAnimation = GetComponent<Animator>();
        PlayerAudio = GetComponent<AudioSource>();
        Physics.gravity *= GravityModifier;
    }

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
