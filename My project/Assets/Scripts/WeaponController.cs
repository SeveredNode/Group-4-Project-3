using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{


    private Transform BulletTransform;
    private Camera Camera;
    public GameObject Player;
    public Transform BulletSpawn;
    public GameObject basicBullet;
    public GameObject bullet2;
    public GameObject rocket;
    PlayerController playerScript;
    public GameObject player;
    public int frameCounter;
    public int frameCounterBulletStorm;
    public float secondCounter;
    public float gunFireRate; //fire every "fireRate" seconds
    public float rocketFireRate;
    public float shotgunFireRate;
    public bool mouseButtonDown;
    Transform scatterShot1;
    Transform scatterShot2;
    float fireAngle;
    float fireAngle2;
    public bool bulletStormActive;
    public float bulletStormRotationSpeed;
    public float bulletStormFireRate;
    public GameObject shieldObject;
    public float shieldCooldown;
    public float shieldTimerCount;
    public int shieldTimerFrames;
    public bool shieldReady;
    public float shieldDuration;


    // Start is called before the first frame update
    void Awake()
    {
        Camera = Camera.main;
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        mouseButtonDown = false;
        scatterShot1 = transform;
        scatterShot2 = transform;
        fireAngle2 = 1f;
        shieldTimerFrames = 1;
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        secondCounter = frameCounter / 50f;
        shieldTimerCount = shieldTimerFrames / 50f;

        ManageMouseAiming();

        ManageMouse();

        Shoot();

        ShootBulletStorm();

        ManageShield();

    }


    private void FixedUpdate()
    {
        frameCounter++;
        shieldTimerFrames++;
        fireAngle2 = fireAngle2 + bulletStormRotationSpeed;
    }



    void Shoot()
    {
        if (mouseButtonDown)
        {

            if (playerScript.hasGunEquipped && playerScript.hasGun)
            {
                if (secondCounter >= gunFireRate)
                {
                    Instantiate(basicBullet, BulletSpawn.position, transform.rotation);
                    secondCounter = 0f;
                    frameCounter = 0;
                }
            }

            if (playerScript.hasShotgunEquipped && playerScript.hasShotgun)
            {
                bool shoot = true;

                if (secondCounter >= shotgunFireRate)
                {
                    if (shoot)
                    {
                        Instantiate(basicBullet, BulletSpawn.position, transform.rotation);
                    }

                    if (shoot)
                    {
                        scatterShot1.rotation = Quaternion.Euler(0, 0, fireAngle + 10);
                        Instantiate(basicBullet, BulletSpawn.position, scatterShot1.rotation);
                    }

                    if (shoot)
                    {
                        scatterShot2.rotation = Quaternion.Euler(0, 0, fireAngle - 10);
                        Instantiate(basicBullet, BulletSpawn.position, scatterShot2.rotation);
                    }
                    secondCounter = 0f;
                    frameCounter = 0;
                }
            }


            if (playerScript.hasRocketEquipped && playerScript.hasRocket)
            {
                if (secondCounter >= rocketFireRate)
                {
                    Instantiate(rocket, BulletSpawn.position, transform.rotation);
                    secondCounter = 0f;
                    frameCounter = 0;
                }
            }


        }

        
           
        

    }

    void ManageMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseButtonDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseButtonDown = false;
        }
    }


    void ShootBulletStorm()
    {
        if (playerScript.hasBulletStormEquipped && playerScript.hasBulletStorm)
        {
            
            bulletStormActive = true;
            
            
            transform.rotation = Quaternion.Euler(0f, 0f, fireAngle2);

            if (secondCounter >= bulletStormFireRate)
            {
                Instantiate(basicBullet, BulletSpawn.position, transform.rotation);
                secondCounter = 0;
                frameCounter = 0;
            }

        }

        if (playerScript.hasBulletStormEquipped == false)
        {
            bulletStormActive = false;
        }
    }

    void ManageMouseAiming()
    {
        if (bulletStormActive == false)
        {
            Vector3 AimerLocation = Camera.ScreenToWorldPoint(Input.mousePosition);

            Vector3 AimerRotation = AimerLocation - transform.position;

            fireAngle = Mathf.Atan2(AimerRotation.y, AimerRotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, fireAngle);
        }
    }

    void ManageShield()
    {
        if(shieldTimerCount >= shieldCooldown && playerScript.hasShieldEquipped && playerScript.hasShield)
        {

            Instantiate(shieldObject, transform.position, transform.rotation);
            shieldTimerCount = 0;
            shieldTimerFrames = 0;

        }

        if(shieldTimerCount >= shieldDuration)
        {
            playerScript.hasShieldEquipped = false;
        }


    }


}
