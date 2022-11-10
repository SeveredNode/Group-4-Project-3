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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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



}
