using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        GameObject obj = collider.gameObject;
        if (obj.name == "Projectile(Clone)" || obj.name == "Player")
        {
            SoundManager.PlaySound("healthUp");
            Healthbar healthbar = FindObjectOfType<Healthbar>();
            healthbar.IncreaseHealth(25);
        }
        Destroy(gameObject);
    }
}
