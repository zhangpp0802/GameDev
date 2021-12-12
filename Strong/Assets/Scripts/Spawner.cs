using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject EnemyPrefab;
    public GameObject HealthItemPrefab;
    public GameObject UpgradeSpeedPrefab;
    public GameObject UpgradeDamagePrefab;

    private float enemySpawnTime;
    private float enemySpawnInterval;

    private float healthSpawnTime;
    private float healthSpawnInterval;
    private float healthSpeed;

    private float upgradeSpeedSpawnTime;
    private float upgradeSpeedSpawnInterval;
    private float upgradeSpeedSpeed;

    private float upgradeDamageSpawnTime;
    private float upgradeDamageSpawnInterval;
    private float upgradeDamageSpeed;

    private Scoreboard scoreboard;

    Vector2 Min;
    Vector2 Max;

    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();

        Min = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        Max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Max.y -= 10;
        Min.y += 10;

        enemySpawnTime = 0;
        enemySpawnInterval = 0.75f;

        healthSpawnTime = 0;
        healthSpawnInterval = 7.5f;
        healthSpeed = 20;

        upgradeSpeedSpawnTime = 0;
        upgradeSpeedSpawnInterval = 12.5f;
        upgradeSpeedSpeed = 20;

        upgradeDamageSpawnTime = 0;
        upgradeDamageSpawnInterval = 25;
        upgradeDamageSpeed = 20;
    }

    void Update()
    {
        if (Time.time > enemySpawnTime)
        {
            GameObject enemyObject = Instantiate(EnemyPrefab, new Vector3(Max.x, Random.Range(Min.y+10, Max.y-10), 0), Quaternion.identity);
            Rigidbody2D rigidbody = enemyObject.GetComponent<Rigidbody2D>();
            rigidbody.freezeRotation = true;
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            enemy.SetMaxHealth(Mathf.Floor(scoreboard.GetScore() / 10) + 1);
            enemy.SetCurrHealth(Mathf.Floor(scoreboard.GetScore() / 10) + 1);
            enemySpawnTime = Time.time + Random.Range(enemySpawnInterval, enemySpawnInterval * 2);
        }
        if (Time.time > healthSpawnTime)
        {
            GameObject healthObject = Instantiate(HealthItemPrefab, new Vector3(Max.x, Random.Range(Min.y + 10, Max.y - 10), 0), Quaternion.identity);
            Rigidbody2D rigidbody = healthObject.GetComponent<Rigidbody2D>();
            rigidbody.velocity = healthSpeed * new Vector2(-1, 0); ;
            healthSpawnTime = Time.time + Random.Range(healthSpawnInterval, healthSpawnInterval * 2);
        }

        if (Time.time > upgradeSpeedSpawnTime)
        {
            GameObject upgradeSpeedObject = Instantiate(UpgradeSpeedPrefab, new Vector3(Max.x, Random.Range(Min.y + 10, Max.y - 10), 0), Quaternion.identity);
            Rigidbody2D rigidbody = upgradeSpeedObject.GetComponent<Rigidbody2D>();
            rigidbody.velocity = upgradeSpeedSpeed * new Vector2(-1, 0); ;
            upgradeSpeedSpawnTime = Time.time + Random.Range(upgradeSpeedSpawnInterval, upgradeSpeedSpawnInterval * 2);
        }
        if (Time.time > upgradeDamageSpawnTime)
        {
            GameObject upgradeDamageObject = Instantiate(UpgradeDamagePrefab, new Vector3(Max.x, Random.Range(Min.y + 10, Max.y - 10), 0), Quaternion.identity);
            Rigidbody2D rigidbody = upgradeDamageObject.GetComponent<Rigidbody2D>();
            rigidbody.velocity = upgradeDamageSpeed * new Vector2(-1, 0); ;
            upgradeDamageSpawnTime = Time.time + Random.Range(upgradeDamageSpawnInterval, upgradeDamageSpawnInterval * 2);
        }
    }
}
