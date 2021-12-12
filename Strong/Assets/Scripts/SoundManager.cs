using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip normalFireSound, cannonFireSound, gameOverSound, explosionSound, healthUpSound, hurtSound;
    static AudioSource audioSource;


    void Start()
    {
        normalFireSound = Resources.Load<AudioClip>("normalFire");
        cannonFireSound = Resources.Load<AudioClip>("cannonFire");
        gameOverSound = Resources.Load<AudioClip>("gameOver");
        explosionSound = Resources.Load<AudioClip>("explosion");
        healthUpSound = Resources.Load<AudioClip>("healthUp");
        hurtSound = Resources.Load<AudioClip>("hurt");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "normalFire":
                audioSource.PlayOneShot(normalFireSound);
                break;
            case "cannonFire":
                audioSource.PlayOneShot(cannonFireSound);
                break;
            case "gameOver":
                audioSource.PlayOneShot(gameOverSound);
                break;
            case "explosion":
                audioSource.PlayOneShot(explosionSound);
                break;
            case "healthUp":
                audioSource.PlayOneShot(healthUpSound);
                break;
            case "hurt":
                audioSource.PlayOneShot(hurtSound);
                break;
        }
    }
}
