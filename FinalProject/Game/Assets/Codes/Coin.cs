using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    Rigidbody rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.rotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + Time.fixedDeltaTime);
        var RotateQuat = Quaternion.Euler(new Vector3(0, Time.time * 50.0f, 0));
        rd.MoveRotation(RotateQuat);
    }

    public void PlaySound()
    {
        
        audioSource.PlayOneShot(audioClip);
    }
}
