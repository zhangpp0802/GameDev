using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private float damage;

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        GameObject colliderObject = collider.gameObject;
        if (colliderObject.name != "Projectile(Clone)" && colliderObject.name != "Player")
        {
            Destroy(gameObject);
        }
    }

    public void SetDamage(float amount)
    {
        damage = amount;
    }

    public float GetDamage()
    {
        return damage;
    }
}
