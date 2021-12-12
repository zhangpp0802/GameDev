using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    public Healthbar healthbar;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        GameObject colliderObject = collider.gameObject;
        if (colliderObject.name == "Enemy(Clone)")
        {
            Enemy enemy = colliderObject.GetComponent<Enemy>();
            if (enemy)
            {
                float damage = 20f * enemy.GetCurrentHealth() / enemy.GetMaxHealth();
                healthbar.DecreaseHealth(damage);
            }
        }
        Destroy(colliderObject);
    }
}
