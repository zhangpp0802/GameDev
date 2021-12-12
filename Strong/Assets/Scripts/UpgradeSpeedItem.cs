using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpeedItem : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        GameObject obj = collider.gameObject;
        if (obj.name == "Projectile(Clone)" || obj.name == "Player")
        {
            Player player = FindObjectOfType<Player>();
            player.IncreaseUpgradeSpeed(80);
        }
        Destroy(gameObject);
    }
}
