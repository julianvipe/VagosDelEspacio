using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed=10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float fireRate = 0.5f;

    [Header("AI")]
    [SerializeField] bool useAI=false;
    [SerializeField] float timeBetweenProjectileSpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    bool isFiring;
    Vector2 direction= Vector2.up;
    
    Coroutine fireCoroutine;

    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
            direction = Vector2.down;
        }
    }
    void Update()
    {
        Fire();

        if (useAI)
        {
            float timeR = Random.Range(timeBetweenProjectileSpawns - spawnTimeVariance, timeBetweenProjectileSpawns + spawnTimeVariance);
            fireRate = Mathf.Clamp(fireRate, minimumSpawnTime , float.MaxValue);
        }
    }

    public void setIsFiring(bool isFiring) {
        this.isFiring = isFiring;
    }
    private void Fire()
    {
        if(isFiring && fireCoroutine==null) 
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && fireCoroutine!=null) 
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instatiate = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            
            Rigidbody2D rb = instatiate.GetComponent<Rigidbody2D>();
            if (rb != null) { 
            rb.velocity=direction*projectileSpeed;
            }

            Destroy(instatiate, projectileLifeTime);

            if (useAI)
            {
                audioPlayer.PlayShootingEnemyClip();
            }
            else
            {
                audioPlayer.PlayShootingClip();
            }

            yield return new WaitForSeconds(fireRate);
        }
    }
}
