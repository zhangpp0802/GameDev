using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthbar : MonoBehaviour
{

    private Transform bar;
    private Transform barSprite;

    void Awake()
    {
        bar = transform.Find("Bar");
        barSprite = bar.Find("BarSprite");
    }

    public void SetHealth(float normalizedHealth)
    {
        if (bar)
        {
            bar.localScale = new Vector3(normalizedHealth, 1f);
            barSprite.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.green, normalizedHealth);
        }
    }

}
