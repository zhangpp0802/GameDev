using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Control the player on screen
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    /// <summary>
    /// Prefab for the orbs we will shoot
    /// </summary>
    public GameObject OrbPrefab;

    /// <summary>
    /// How fast our engines can accelerate us
    /// </summary>
    public float EnginePower = 1;

    private double playerAScore = 5;
    private double playerBScore = 5;
    
    /// <summary>
    /// How fast we turn in place
    /// </summary>
    public float RotateSpeed = 1;

    /// <summary>
    /// How fast we should shoot our orbs
    /// </summary>
    public float OrbVelocity = 10;

    // private AudioSource audioSource;
    // public AudioClip shoot;

    private Rigidbody2D playerObj;

    private bool fireEnable = false;
    // public AudioSource audioSource;

    void Start()
    {
        playerObj = GetComponent<Rigidbody2D>();
        // audioSource = GameObject.Find("AudioHandler").GetComponent<AudioSource>();
    }

    /// <summary>
    /// Reload the current level
    /// </summary>
    private void ResetForFiring()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator waitASecond(){
        yield return new WaitForSeconds(5);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.collider.name == "Enemy(Clone)")){ 
            fireEnable = true;
            GameObject x = GameObject.Find("Enemy(Clone)");
            Destroy(x);
        }   
    }

    /// <summary>
    /// Fire if the player is pushing the button for the Fire axis
    /// Unlike the Enemies, the player has no cooldown, so they shoot a whole blob of orbs
    /// The orb should be placed one unit "in front" of the player.  transform.right will give us a vector
    /// in the direction the player is facing.
    /// It should move in the same direction (transform.right), but at speed OrbVelocity.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Update()
    {
        if ((this.name == "PlayerA") && (fireEnable)){
            if (Input.GetKeyDown(KeyCode.Space)){
                Vector2 dir = this.transform.right;
                GameObject orb = Instantiate(OrbPrefab);
                Rigidbody2D orbrb = orb.GetComponent<Rigidbody2D>();
                orb.transform.position = new Vector2(this.transform.position.x+dir.x,this.transform.position.y+dir.y);
                orbrb.velocity = OrbVelocity*this.transform.right;
            }
        }
        if ((this.name == "PlayerB") && (fireEnable)){
            if (Input.GetKeyDown(KeyCode.Return)){
                Vector2 dir = -this.transform.right;
                GameObject orb = Instantiate(OrbPrefab);
                Rigidbody2D orbrb = orb.GetComponent<Rigidbody2D>();
                orb.transform.position = new Vector2(this.transform.position.x-1,this.transform.position.y);
                orbrb.velocity = OrbVelocity*dir;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            ResetForFiring();
        }
    }

    /// <summary>
    /// Accelerate and rotate as directed by the player
    /// Apply a force in the direction (Horizontal, Vertical) with magnitude EnginePower
    /// Note that this is in *world* coordinates, so the direction of our thrust doesn't change as we rotate
    /// Set our angularVelocity to the Rotate axis time RotateSpeed
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void FixedUpdate()
    {
        if (this.name == "PlayerA"){
            if (Input.GetKeyDown(KeyCode.W)){
                this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y+0.5f);
                // Debug.Log("up");
            }
            if (Input.GetKeyDown(KeyCode.S)){
                this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y-0.5f);

            }
            if (Input.GetKeyDown(KeyCode.A)){
                this.transform.position = new Vector2(this.transform.position.x-0.5f,this.transform.position.y);

            }
            if (Input.GetKeyDown(KeyCode.D)){
                this.transform.position = new Vector2(this.transform.position.x+0.5f,this.transform.position.y);

            }
            if (Input.GetKeyDown(KeyCode.R)){
                playerObj.angularVelocity = RotateSpeed*-45;
            }
            if (Input.GetKeyDown(KeyCode.T)){
                playerObj.angularVelocity = RotateSpeed*45;
            }
        }
        if (this.name == "PlayerB"){
            if (Input.GetKeyDown(KeyCode.UpArrow)){
            this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y+0.5f);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow)){
                this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y-0.5f);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)){
                this.transform.position = new Vector2(this.transform.position.x-0.5f,this.transform.position.y);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)){
                this.transform.position = new Vector2(this.transform.position.x+0.5f,this.transform.position.y);
            }
            if (Input.GetKeyDown(KeyCode.P)){
                playerObj.angularVelocity = RotateSpeed*-45;
            }
            if (Input.GetKeyDown(KeyCode.O)){
                playerObj.angularVelocity = RotateSpeed*45;
            }
        }
    }

    /// <summary>
    /// If this is called, we got knocked off screen.  Deduct a point!
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void OnBecameInvisible()
    {
        if(this.name == "PlayerB"){
            playerBScore -= 1;
            ScoreKeeper.ScorePoints(0,-1);
        }
        else if(this.name == "PlayerA"){
            playerAScore -= 1;
            ScoreKeeper.ScorePoints(-1,0);
        }
        // if (this.name == "PlayerB"){
        // }
    }
}
