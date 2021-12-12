using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{

    public GameOverScreen gameOverScreen;
    public Scoreboard scoreboard;

    private Transform bar;
    private Transform barSprite;
    private float health;

    void Start()
    {
        health = 100;
        bar = transform.Find("Bar");
        barSprite = bar.Find("BarSprite");
    }

    public void GameOver()
    {
        gameOverScreen.Setup(scoreboard.GetScore());
        Time.timeScale = 0;
    }

    public void SetHealth(float amount)
    {
        if (bar)
        {
            health = amount;
            bar.localScale = new Vector3(amount/100, 1f);
            barSprite.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.green, amount/100);
        }
    }

    public void DecreaseHealth(float amount)
    {
        if (amount >= health)
        {
            SoundManager.PlaySound("gameOver");
            GameOver();
        }
        else
        {
            SoundManager.PlaySound("hurt");
            float newHealth = health - amount;
            SetHealth(newHealth);
        }
    }

    public void IncreaseHealth(float amount)
    {
        if (amount + health >= 100)
        {
            SetHealth(100);
        }
        else
        {
            float newHealth = health + amount;
            SetHealth(newHealth);
        }
    }

}
