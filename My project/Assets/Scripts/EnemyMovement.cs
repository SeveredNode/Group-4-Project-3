using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Rigidbody2D RB;
    public Vector2 moveDirection;
    public float horizontalSpeed;
    public PlayerController playerScript;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = new Vector2(-1, -3);
        player = GameObject.Find("Player");
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(player.transform.position.x >= transform.position.x)
        {
            moveDirection = new Vector2(1,moveDirection.y);
        }

        if (player.transform.position.x <= transform.position.x)
        {
            moveDirection = new Vector2(-1, moveDirection.y);
        }


        RB.MovePosition(RB.position + (moveDirection * horizontalSpeed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        /*if(other.gameObject.tag == ("Enemy"))
        {
            Physics.IgnoreCollision();
        }*/
    }


}
