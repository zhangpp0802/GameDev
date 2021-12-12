using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemyHealthbar enemyHealthbar;
    public float maxHealth;
    public float currHealth;

    private float enemySpeed;
    private Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
        enemySpeed = 25;
    }

    private void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody.velocity;
        velocity.y = 0;
        rigidbody.velocity = enemySpeed * new Vector2(-1, 0);
    }

    public float GetCurrentHealth()
    {
        return currHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetCurrHealth(float amount)
    {
        currHealth = amount;
        enemyHealthbar.SetHealth(currHealth / maxHealth);
    }

    public void SetMaxHealth(float amount)
    {
        maxHealth = amount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        GameObject colliderObject = collider.gameObject;
        if (colliderObject.name == "Projectile(Clone)")
        {
            Projectile projectile = colliderObject.GetComponent<Projectile>();
            if (projectile)
            {
                float damage = projectile.GetDamage();
                if (damage >= currHealth)
                {
                    Destroy(gameObject);
                    scoreboard.IncrementScore();
                    SoundManager.PlaySound("explosion");
                }
                else
                {
                    SetCurrHealth(currHealth - damage);
                }
            }
        }
    }

}
