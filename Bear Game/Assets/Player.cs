using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D playerObj;
    private float translationy;
    private float translationx;
    private SpriteRenderer person;
    public static bool fireEnable = false;
    private bool changeSprite = true;
    

    public float speed;
    public float OrbVelocity = 5;
    public float FreeRadius = 10;
    public float RotateSpeed = 0.3f;
    public GameObject OrbPrefab;
    public Sprite sprite1;
    public Sprite sprite2;
    


    void Start()
    {
        playerObj = GetComponent<Rigidbody2D>();
        person = GetComponent<SpriteRenderer>();
        person.sprite = sprite1;
    }

    // Update is called once per frame
    void Update()
    {
        // bool fireOnce = true;
        float fire = Input.GetAxis("Fire1");
        if (fire == 1 && fireEnable){
            Fire();
            fireEnable = true;
        }
    }
    void FixedUpdate(){
        translationy = Input.GetAxis("Vertical") * speed;
        translationx = Input.GetAxis("Horizontal") * speed;
        this.transform.position = new Vector2(this.transform.position.x+translationx,this.transform.position.y+translationy);
        if((translationx != 0) && (translationy !=0)){
            if(changeSprite){
                person.sprite = sprite2;
                changeSprite = false;
            }
            else{
                person.sprite = sprite1;
                changeSprite = true;
            }
        }
        float x = Input.GetAxis("Rotate");
        this.transform.Rotate(new Vector3(0.0f,0.0f,RotateSpeed*x));
        // playerObj.AddTorque(RotateSpeed*x);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.collider.name == "bear")){ 
            // ResetForFiring();
            SceneManager.LoadScene("LoseScene");
        }   
        else if((collision.collider.name == "weapon")){ 
            // ResetForFiring();
            // GameObject.Find("weapon").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("weapon").transform.SetParent(this.transform);
            fireEnable = true;
        }  
    }

    private void Fire()
    {
        Vector2 dir = this.transform.right;
        GameObject orb = Instantiate(OrbPrefab);
        Rigidbody2D orbrb = orb.GetComponent<Rigidbody2D>();
        orb.transform.position = new Vector2(this.transform.position.x+1,this.transform.position.y);
        orbrb.velocity = OrbVelocity*dir;
    }
}
