using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rg;
    public float maxspeed;
    public float Horispeed;
    public float VerSpeed;
    public float jumpScale;
    public float lastTime;
    private ScoreKeeper scoreKeeper;
    private float scalingTime;
    public Menu gameover;
    public Menu gamestart;
    public AudioClip audioClip;
    public AudioClip mushroomSound;
    private AudioSource audioSource;


    void Start()
    {
        rg = GetComponent<Rigidbody>();
        lastTime = 0;
        scalingTime = float.PositiveInfinity;
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 0;
        gamestart.Setup();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > scalingTime)
        {
            transform.localScale = new Vector3(transform.localScale.x * 0.5f, transform.localScale.y, transform.localScale.z * 0.5f);
            scalingTime = float.PositiveInfinity;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rg.AddForce((-1) * rg.transform.right * Horispeed);
            //Debug.Log("Horizontal A");
        }
        if (Input.GetKey(KeyCode.D))
        {
            rg.AddForce(rg.transform.right * Horispeed);
            //Debug.Log("Horizontal D");
        }
        if (Input.GetKey(KeyCode.W))
        {
            rg.AddForce(rg.transform.forward *  VerSpeed);
            //Debug.Log("Vertical W");
        }
        if (Input.GetKey(KeyCode.S))
        {
            rg.AddForce(rg.transform.forward * (-1) * VerSpeed);
            //Debug.Log("Vertical S");
        }
        if (Input.GetKey(KeyCode.Space) && Time.time - lastTime > 1.0f)
        {
            rg.AddForce(transform.up * jumpScale, ForceMode.Impulse);
            lastTime = Time.time;
            //Debug.Log("Jump");
            audioSource.PlayOneShot(audioClip);
        }
        //float hori = Input.GetAxis("Horizontal");
        //if (hori != 0)
        //{
        //    rg.AddForce(hori * rg.transform.right*Horispeed);
        //    //Debug.Log("Horizontal");
        //}
        //float ver = Mathf.Min(Input.GetAxis("Vertical"), maxspeed);
        //if (ver != 0)
        //{
        //    rg.AddForce(ver * rg.transform.forward * (-1) * VerSpeed);
        //    //Debug.Log("Vertical");
        //}
        //float jump = Input.GetAxis("Jump");
        //if(jump == 1 && Time.time - lastTime > 1.0f)
        //{
        //    rg.AddForce(transform.up*jumpScale,ForceMode.Impulse);
        //    lastTime = Time.time;
        //    //Debug.Log("Jump");
        //    audioSource.PlayOneShot(audioClip);
        //}

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            ScoreKeeper.ScorePoints(1);
            // Debug.Log("Eat Coin");
            FindObjectOfType<Coin>().PlaySound();
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "Mushroom")
        {
            ScoreKeeper.ScorePoints(5);
            // Debug.Log("Eat Mushroom");
            // FindObjectOfType<Mushroom>().PlaySound();
            audioSource.PlayOneShot(mushroomSound);
            Destroy(collider.gameObject);
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y, transform.localScale.z * 2);
            scalingTime = Time.time + 3.0f;
        }
        else if (collider.gameObject.tag == "Wood")
        {
            //ScoreKeeper.AddScore(1);
            // Debug.Log("Wood");
            rg.velocity = rg.velocity / 10;
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "FinishLine")
        {
            // Debug.Log("FinishLine");
            gameover.Setup();
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Stone")
        {
            collision.gameObject.GetComponent<Stone>().PlaySound();
        }
    }
}
