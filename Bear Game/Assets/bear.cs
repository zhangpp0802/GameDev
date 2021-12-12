using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bear : MonoBehaviour
{

    public GameObject play;
    public float OrbVelocity = 5;
    public float OrbMass = .5f;
    public float CoolDownTime = 10;
    public GameObject OrbPrefab;
    public static int bearNum;
    public static int numLeft;

    // Start is called before the first frame update
    private Rigidbody2D enemyObj;
    private Rigidbody2D playerObj;
    private Vector2 OffsetToPlayer => playerObj.transform.position - enemyObj.transform.position;
    private Vector2 HeadingToPlayer => OffsetToPlayer.normalized;
    private bool fireEnable = true;
    private float chasestep = 0.001f;
    private float escapestep = 0.008f;
    private AudioSource audioSource;
    private AudioClip clip;

    void Start()
    {
        enemyObj = GetComponent<Rigidbody2D>();
        playerObj = play.GetComponent<Rigidbody2D>();
        bearNum = Random.Range(1,10);
        numLeft = bearNum;
    }

    private int i = 0;
    // Update is called once per frame
    void Update()
    {
        fireEnable = !Player.fireEnable;
        float norm = Mathf.Sqrt(Mathf.Pow(HeadingToPlayer.x,2)+Mathf.Pow(HeadingToPlayer.y,2));
        Vector2 unithead= new Vector2(HeadingToPlayer.x/norm,HeadingToPlayer.y/norm);
        if(fireEnable){
            this.transform.position = new Vector2(this.transform.position.x+unithead.x*chasestep,this.transform.position.y+unithead.y*chasestep);
            // this.transform.position = new Vector2(this.transform.position.x-unithead.x*escapestep,this.transform.position.y-unithead.x*escapestep);
            if (Time.time >= CoolDownTime*i){
                Fire();
                i++;
            }
        }
        else{
            this.transform.position = new Vector2(this.transform.position.x-unithead.x*escapestep,this.transform.position.y-unithead.x*escapestep);
            // random a place
            // transform.position = SpawnUtilities.RandomFreePoint(10);
        }
    }

    private void Fire()
    {
        GameObject orb = Instantiate(OrbPrefab);
        Rigidbody2D orbrb = orb.GetComponent<Rigidbody2D>();
        orbrb.mass = OrbMass;
        orb.transform.position = new Vector2(this.transform.position.x+HeadingToPlayer.x,this.transform.position.y+HeadingToPlayer.y);
        orbrb.velocity = OrbVelocity*HeadingToPlayer;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.collider.name == "PlayerOrb(Clone)")){ 
            numLeft-=1;
            // Debug.Log("bearNum"+bearNum);
            if(numLeft == 0){}
            else{        
                audioSource = this.GetComponent<AudioSource>();
                clip = audioSource.clip;
                initiateBeer();
                // Debug.Log(this.transform.position);
                }
        }
        if((collision.collider.name == "weapon")){ 
            SceneManager.LoadScene("SampleScene");
        }   
    }
    private void initiateBeer(){
        this.transform.position = new Vector2(SpawnUtilities.RandomFreePoint(10).x,SpawnUtilities.RandomFreePoint(20).y);
    }
}
