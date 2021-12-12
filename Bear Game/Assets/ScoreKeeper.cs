using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    private TMP_Text scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GetComponent<TMP_Text>();
        // GameObject.Find("WinScene").GetComponent<TMP_Text>().enable = false;
    }

    // Update is called once per frame
    void Update()
    {
        string text;
        int totalNum = bear.bearNum;
        int left = bear.numLeft;
        // Debug.Log("left"+left);
        if (left <= 0){
            //you win
            // GameObject.Find("WinScene").GetComponent<TMP_Text>().enable = true;
            SceneManager.LoadScene("WinScene");
        }
        else{
            text = "Bear Left: "+ left.ToString();
            scoreDisplay.SetText(text);
            }
    }
}
