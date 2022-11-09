using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float MoveDirection;
    Rigidbody2D RB;
    public float JumpHeight;
    public bool IsJumping;
    public bool DoubleJumpReady;
    public float Health;

    public bool hasShield;
    public bool hasShieldEquipped;
    public bool hasRocket;
    public bool hasRocketEquipped;
    public bool hasGun;
    public bool hasGunEquipped;

    public Vector3 SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = transform.position;
    }

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();

    }

    void KillPlayer()
    {
        transform.position = SpawnPoint;
        Health = 3;
    }


    // Update is called once per frame
    void Update()
    {
        ManageMovement();
        ManageWeaponSwapping();
        

        if (Health <= 0)
        {
            KillPlayer();
        }



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
            hasRocketEquipped = false;
            hasShieldEquipped = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hasGunEquipped = false;
            hasRocketEquipped = true;
            hasShieldEquipped = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            hasGunEquipped = false;
            hasRocketEquipped = false;
            hasShieldEquipped = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            SpawnPoint = transform.position;
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
            Health = 0;
        }



    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("platform") || other.gameObject.CompareTag("EnemyPlatform"))
        {
            IsJumping = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        IsJumping = false;
        DoubleJumpReady = false;

    }

}
