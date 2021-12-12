using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject ProjectilePrefab;

    private float projectileCooldown;
    private float projectileSpeed;
    private float lastFired;
    private float damage;
    private int upgradeSpeedRemaining;
    private int upgradeDamageRemaining;
    private Vector3 projectileScale;

    // Start is called before the first frame update
    void Start()
    {
        projectileCooldown = 0.3f;
        projectileSpeed = 100f;
        lastFired = 0;
        damage = 1;
        upgradeSpeedRemaining = 0;
        upgradeDamageRemaining = 0;
        projectileScale = new Vector3(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // Player tracks current mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.x = -122;
        if (mousePos.y < -100)
        {
            mousePos.y = -100;
        }
        else if (mousePos.y > 100)
        {
            mousePos.y = 100;
        }
        transform.position = mousePos;

        // If rapid firing mode is on, decrease firing cooldown
        if (upgradeSpeedRemaining > 0)
        {
            projectileCooldown = 0.05f;
        }
        else
        {
            projectileCooldown = 0.3f;
        }

        // If high damage mode is on, increase bullet damage
        if (upgradeDamageRemaining > 0)
        {
            damage = 5;
            projectileScale = new Vector3(9, 9);
        }
        else
        {
            damage = 1;
            projectileScale = new Vector3(3, 3);
        }

        // On left click, fire projectile
        if (Input.GetMouseButton(0) && (Time.time - lastFired) >= projectileCooldown)
        {
            if (upgradeSpeedRemaining > 0)
            {
                upgradeSpeedRemaining -= 1;
            }
            if (upgradeDamageRemaining > 0)
            {
                SoundManager.PlaySound("cannonFire");
                upgradeDamageRemaining -= 1;
            }
            else
            {
                SoundManager.PlaySound("normalFire");
            }
            Vector3 offset = transform.right;
            Vector3 playerPos = transform.position;
            Vector3 projectilePos = playerPos + offset * 10;
            GameObject projectile = Instantiate(ProjectilePrefab, projectilePos, Quaternion.identity);
            Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
            rigidbody.velocity = projectileSpeed * transform.right;
            rigidbody.freezeRotation = true;
            projectile.GetComponent<Projectile>().SetDamage(damage);
            projectile.transform.localScale = projectileScale;
            lastFired = Time.time;
        }
    }

    public void IncreaseUpgradeSpeed(int amount)
    {
        upgradeSpeedRemaining += amount;
    }

    public void IncreaseUpgradeDamage(int amount)
    {
        upgradeDamageRemaining += amount;
    }
}
