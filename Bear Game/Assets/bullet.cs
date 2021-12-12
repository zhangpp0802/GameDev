using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float CoolDownTime;
    public GameObject BearPrefab;
    public GameObject WeaponPrefab;
    private AudioSource audioSource;
    private AudioClip clip;
    // public int numleft;
    // Start is called before the first frame update
    void Start()
    {
        //get bear num
        // numleft = bear.bearNum;
        audioSource = this.GetComponent<AudioSource>();
        clip = audioSource.clip;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name != "PlayerOrb(Clone)"){
            audioSource.PlayOneShot(clip, 0.3F);
            Destroy(this.gameObject);
        }
    }

}
