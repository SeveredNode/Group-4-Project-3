using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
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
    public float secondCounter;
    public float fireRate; //fire every "fireRate" seconds
    public bool mouseButtonDown;



    // Start is called before the first frame update
    void Awake()
    {
        Camera = Camera.main;
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        mouseButtonDown = false;
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondCounter = frameCounter / 50f;

        Vector3 AimerLocation = Camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 AimerRotation = AimerLocation - transform.position;

        float FireAngle = Mathf.Atan2(AimerRotation.y, AimerRotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, FireAngle);

        ManageMouse();

        Shoot();

       


    }


    private void FixedUpdate()
    {
        frameCounter++;
    }



    void Shoot()
    {
        if (mouseButtonDown)
        {

            if (playerScript.hasGun)
            {
                if (secondCounter >= fireRate)
                {
                    Instantiate(basicBullet, BulletSpawn.position, transform.rotation);
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



}
