using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("ShootingPlayer")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 1f;

    [Header("ShootingEnemmy")]
    [SerializeField] AudioClip shootingClipE;
    [SerializeField][Range(0f, 1f)] float shootingVolumeE = 1f;

    [Header("Explotion")]
    [SerializeField] AudioClip explotionClip;
    [SerializeField][Range(0f, 1f)] float explotionVolume = 1f;

    [Header("Hit")]
    [SerializeField] AudioClip hitClip;
    [SerializeField][Range(0f, 1f)] float hitVolume = 1f;

    static AudioPlayer instance;

    private void Awake()
    {
        ManageSingleton();
    }
    public void ManageSingleton()
    {
        if(instance != null) 
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayShootingClip()
    {
        if(shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, 
                                        Camera.main.transform.position, 
                                        shootingVolume);
        }
    }
    public void PlayShootingEnemyClip()
    {
        if (shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClipE,
                                        Camera.main.transform.position,
                                        shootingVolumeE);
        }
    }
    public void PlayExplotionClip()
    {
        if (shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(explotionClip,
                                        Camera.main.transform.position,
                                        explotionVolume);
        }
    }

    public void PlayHitClip()
    {
        if (shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(hitClip,
                                        Camera.main.transform.position,
                                        hitVolume);
        }
    }

}
