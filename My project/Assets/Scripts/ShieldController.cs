using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{

    public GameObject playerObject;
    public PlayerController playerScript;
    public WeaponController weaponScript;
    float health;
    int frameCounter;
    float secondCounter;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        weaponScript = GameObject.Find("ProjectileAimer").GetComponent<WeaponController>();
        frameCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerObject.transform.position;

        if (secondCounter >= weaponScript.shieldCooldown)
        {
            playerScript.hasShieldEquipped = false;
            weaponScript.shieldTimerCount = 0;

        }

    }
    private void FixedUpdate()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            health = health - 1;
        }
    }

}
