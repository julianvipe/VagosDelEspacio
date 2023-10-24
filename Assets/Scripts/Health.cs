using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    GameManager gameManager;
    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();  
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damage=collision.GetComponent<DamageDealer>();

        if (damage != null )
        {
            TakeDamage( damage );
            damage.Hit();
            ShakeCamera();
            PlayHitEffect();
        }
    }
    private void TakeDamage(DamageDealer damage)
    {
        health = health - damage.getDamage();
        if (health <= 0)
        {
            if (!isPlayer)
            {
                scoreKeeper.SetScore(score);
            }
            else { gameManager.LoadGameOver(); }
            audioPlayer.PlayExplotionClip();
            Destroy(gameObject);
            
        }
    }

    private void PlayHitEffect()
    {
        if( hitEffect != null )
        {
            audioPlayer.PlayHitClip();
            ParticleSystem instance = Instantiate( hitEffect,transform.position,Quaternion.identity );
            Destroy( instance,instance.main.duration+instance.main.startLifetime.constantMax );
        }
    }
    private void ShakeCamera()
    {
        if( cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
    public int GetHealth()
    {
        return health;
    }
}
