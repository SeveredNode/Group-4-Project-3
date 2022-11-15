using System.Collections;
using System.Collections.Generic;
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

    

    private Animator playerAnimation;

    public WeaponController weaponScript;
    

    public int frameCounter;



    public Vector3 SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = transform.position;
        frameCounter = 1;
        weaponScript = GameObject.Find("ProjectileAimer").GetComponent<WeaponController>();
        playerAnimation = GetComponent<Animator>();
    }

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();

    }

    void KillPlayer()
    {
        SceneManager.LoadScene("GameOver");
    }


    // Update is called once per frame
    void Update()
    {
        

        ManageMovement();
        ManageWeaponSwapping();
        ShieldBash();

        if (health <= 0)
        {
            KillPlayer();
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(RB.velocity.x));
        playerAnimation.SetBool("OnGround", IsJumping);
    }

    private void FixedUpdate()
    {
        
    }


    void ManageMovement()
    {
        MoveDirection = Input.GetAxis("Horizontal");

        RB.velocity = new Vector2(MoveSpeed * MoveDirection, RB.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsJumping == false)
        {
            RB.AddForce(Vector2.up * JumpHeight * 1.2f, ForceMode2D.Impulse);
            DoubleJumpReady = true;
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

}
