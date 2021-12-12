using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Displays the score in whatever text component is store in the same game object as this
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class ScoreKeeper : MonoBehaviour
{
    /// <summary>
    /// There will only ever be one ScoreKeeper object, so we just store it in
    /// a static field so we don't have to call FindObjectOfType(), which is expensive.
    /// </summary>
    public static ScoreKeeper Singleton;

    public static void ScorePoints(int pointA,int pointB)
    {
        Singleton.ScorePointsInternal(pointA,pointB,false);

    }

    /// <summary>
    /// Current score
    /// </summary>
    private double ScoreA = -1;
    private int ScoreB = -1;

    private AudioSource audioSource;
    // public AudioClip score;

    /// <summary>
    /// Text component for displaying the score
    /// </summary>
    private TMP_Text scoreDisplay;
    
    /// <summary>
    /// Initialize Singleton and ScoreDisplay.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        Singleton = this;
        scoreDisplay = GetComponent<TMP_Text>();

        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        // Debug.Log(audioSource);
        // Initialize the display
        ScorePointsInternal(6,6,true);
    }
    
    /// <summary>
    /// Reload the current level
    /// </summary>
    private void ResetForFiring()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Internal, non-static, version of ScorePoints
    /// </summary>
    /// <param name="delta"></param>
    private void ScorePointsInternal(int deltaA,int deltaB,bool init)
    {
        if(init){ScoreA += deltaA;}
        else{ScoreA += deltaA*0.5;}
        ScoreB += deltaB;
        string text = ScoreA.ToString()+" : "+ ScoreB.ToString();
        scoreDisplay.SetText(text);
        if (ScoreA <= 0){
            scoreDisplay.SetText("Player B Is Win!!!");
            // yield return new WaitForSeconds(5);
            // Application.Quit();
        }
        if (ScoreB <= 0){
            scoreDisplay.SetText("Player A Is Win!!!");
            // yield return new WaitForSeconds(5);
            // Application.Quit();
        }
        audioSource.Play();

        if (deltaB == 0){
        if(ScoreA == 4){
            GameObject leftblood4 = GameObject.Find("leftblood4");
            leftblood4.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        if(ScoreA == 3){
            GameObject leftblood3 = GameObject.Find("leftblood3");
            leftblood3.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        if(ScoreA == 2){
            GameObject leftblood = GameObject.Find("leftblood");
            leftblood.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        if(ScoreA == 1){
            GameObject leftblood1 = GameObject.Find("leftblood1");
            leftblood1.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        if(ScoreA == 0){
            GameObject leftblood2 = GameObject.Find("leftblood2");
            leftblood2.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        }

        else if (deltaA == 0){
        if(ScoreB == 4){
            GameObject leftblood9 = GameObject.Find("leftblood9");
            leftblood9.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        if(ScoreB == 3){
            GameObject leftblood8 = GameObject.Find("leftblood8");
            leftblood8.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        if(ScoreB == 2){
            GameObject leftblood7 = GameObject.Find("leftblood7");
            leftblood7.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        if(ScoreB == 1){
            GameObject leftblood6 = GameObject.Find("leftblood6");
            leftblood6.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        if(ScoreB == 0){
            GameObject leftblood5 = GameObject.Find("leftblood5");
            leftblood5.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        }
    }
}
