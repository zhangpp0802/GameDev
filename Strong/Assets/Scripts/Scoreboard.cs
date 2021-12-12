using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{

    private int scoreValue;
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreValue = 0;
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreValue;
    }

    public void IncrementScore()
    {
        scoreValue += 1;
    }

    public int GetScore()
    {
        return scoreValue;
    }
}
