using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float shotgunPelletDamage;
    public float machineGunDamage;
    public float rocketDamage;
    public float explosionDamage;
    public float bulletStormDamage;
    public float shieldDamage;
    public float health;

    public int frameCounter;
    public float secondCounter;
    public float fireRate;

    public GameObject enemyBullet;
    public GameObject explosion;

    public WaveCounter waveCounterScript;

    

    // Start is called before the first frame update
    void Start()
    {
        waveCounterScript = GameObject.Find("WaveCounter").GetComponent<WaveCounter>();  
    }

    // Update is called once per frame
    void Update()
    {
        secondCounter = frameCounter / 50;

        if (health <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            waveCounterScript.enemiesKilled = waveCounterScript.enemiesKilled + 1;
        }

        ManageShooting();

    }


    private void FixedUpdate()
    {
        frameCounter++;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health = health - machineGunDamage;
        }

        if (other.CompareTag("ShotgunPellet"))
        {
            health = health - shotgunPelletDamage;
        }

        if (other.CompareTag("Rocket"))
        {
            health = health - rocketDamage;
        }

        if (other.CompareTag("Explosion"))
        {
            health = health - explosionDamage;
        }

        if (other.CompareTag("BulletStormBullet"))
        {
            health = health - bulletStormDamage;
        }

        if (other.CompareTag("Shield"))
        {
            health = health - shieldDamage;
        }
    }


    void ManageShooting()
    {
        Vector3 enemyPos;
        enemyPos = transform.position;
        if (secondCounter > fireRate)
        {
            Instantiate(enemyBullet, enemyPos, transform.rotation);
            frameCounter = 0;
        }
    }
}
