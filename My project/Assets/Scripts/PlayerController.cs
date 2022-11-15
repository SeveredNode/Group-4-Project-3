using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float MoveDirection;
    Rigidbody2D RB;
    public float JumpHeight;
    public bool IsJumping;
    public bool DoubleJumpReady;
    public bool hasExploded;
    public float health;
    public float maxHealth;
    public float bashForce;
    public float enemyBulletDamage;

    public bool hasShield;
    public bool hasShieldEquipped;
    public bool hasRocket;
    public bool hasRocketEquipped;
    public bool hasGun;
    public bool hasGunEquipped;
    public bool hasShotgun;
    public bool hasShotgunEquipped;
    public bool hasBulletStorm;
    public bool hasBulletStormEquipped;

    public GameObject highlight;
    public GameObject gunUI;
    public GameObject shotgunUI;
    public GameObject rocketUI;
    public GameObject shieldUI;
    public GameObject droneUI;
    public GameObject explosion;
    public GameObject projectileSpawner;



    private Animator animator;

    public WeaponController weaponScript;
    

    public int frameCounter;



    public Vector3 SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        hasExploded = false;
        highlight = GameObject.Find("Highlight");
        gunUI = GameObject.Find("GunUI");
        shotgunUI = GameObject.Find("ShotgunUI");
        rocketUI = GameObject.Find("RocketUI");
        shieldUI = GameObject.Find("ShieldUI");
        droneUI = GameObject.Find("DroneUI");
        projectileSpawner = GameObject.Find("ProjectileSpawner");
        SpawnPoint = transform.position;
        frameCounter = 1;
        weaponScript = GameObject.Find("ProjectileAimer").GetComponent<WeaponController>();
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        frameCounter = 0;
    }

    void KillPlayer()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        RB.gravityScale = 0;
        if(hasExploded == false)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            hasExploded = true;
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        projectileSpawner.GetComponent<SpriteRenderer>().enabled = false;
        if (frameCounter > 100)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    // Update is called once per frame
    void Update()
    {

        ManageUI();
        if (health > 0)
        {
            ManageMovement();
        }
        ManageWeaponSwapping();
        ShieldBash();

        if (health <= 0)
        {
            KillPlayer();   
        }


        if (health > maxHealth)
        {
            health = maxHealth;
        }

        animator.SetFloat("Speed", Mathf.Abs(MoveDirection));
       
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            frameCounter++;
        }
    }


    void ManageMovement()
    {
        MoveDirection = Input.GetAxis("Horizontal");

        RB.velocity = new Vector2(MoveSpeed * MoveDirection, RB.velocity.y);

        if (MoveDirection > 0)
        {
            transform.localScale = new Vector2(2.7f, 2.7f);   
        }
        if (MoveDirection < 0)
        {
            transform.localScale = new Vector2(-2.7f, 2.7f);
        }
       
        if (Input.GetKeyDown(KeyCode.Space) && IsJumping == false)
        {
            RB.AddForce(Vector2.up * JumpHeight * 1.2f, ForceMode2D.Impulse);
            DoubleJumpReady = true;
        }
        if (IsJumping == true)
        {
            animator.SetBool("IsJumping", true);
        }
        if (IsJumping == false)
        {
            animator.SetBool("IsJumping", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && DoubleJumpReady == true && IsJumping == true)
        {
            RB.velocity = new Vector2(MoveSpeed * MoveDirection, 0);
            RB.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            DoubleJumpReady = false;
        }
    }


    void ManageWeaponSwapping()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            hasGunEquipped = true;
            hasShieldEquipped = false;
            hasShotgunEquipped = false;
            hasRocketEquipped = false;
            hasBulletStormEquipped = false;
            weaponScript.frameCounter = 100;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hasGunEquipped = false;
            hasShotgunEquipped = true;
            hasRocketEquipped = false;
            hasShieldEquipped = false;
            hasBulletStormEquipped = false;
            weaponScript.frameCounter = 100;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            hasGunEquipped = false;
            hasShotgunEquipped = false;
            hasRocketEquipped = true;
            hasShieldEquipped = false;
            hasBulletStormEquipped = false;
            weaponScript.frameCounter = 100;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && weaponScript.shieldCooldown <= weaponScript.shieldTimerCount)
        {
            hasGunEquipped = false;
            hasShotgunEquipped = false;
            hasRocketEquipped = false;
            hasShieldEquipped = true;
            hasBulletStormEquipped = false;
            weaponScript.frameCounter = 100;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            hasGunEquipped = false;
            hasShotgunEquipped = false;
            hasRocketEquipped = false;
            hasShieldEquipped = false;
            hasBulletStormEquipped = true;
            weaponScript.frameCounter = 100;
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            health = health - enemyBulletDamage;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("platform"))
        {
            IsJumping = false;
            DoubleJumpReady = false;
        }

        if (other.gameObject.CompareTag("DeathWall"))
        {
            health = 0;
        }



    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("platform"))
        {
            IsJumping = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        IsJumping = false;
        DoubleJumpReady = false;

    }

    void ShieldBash()
    {
        if (hasShieldEquipped && Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(MoveDirection > 0)
            {
                RB.AddForce(Vector2.right * bashForce, ForceMode2D.Impulse);
            }

            if (MoveDirection < 0)
            {
                RB.AddForce(Vector2.left * bashForce, ForceMode2D.Impulse);
            }

        }
    }

    void ManageUI()
    {
        if (hasGun)
        {
            gunUI.GetComponent<SpriteRenderer>().enabled = true;
            highlight.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (hasShotgun)
        {
            shotgunUI.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (hasRocket)
        {
            rocketUI.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (hasShield)
        {
            shieldUI.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (hasBulletStorm)
        {
            droneUI.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

}
