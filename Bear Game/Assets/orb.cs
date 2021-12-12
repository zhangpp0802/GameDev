using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class orb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("collide");
        if (collision.collider.name != "weapon"){
            Destroy(this.gameObject);
        }
        if (collision.collider.name == "Player"){
            SceneManager.LoadScene("SampleScene");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
