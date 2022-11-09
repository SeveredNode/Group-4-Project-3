using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float BulletSpeed;
    public Rigidbody2D BulletRB;
    public PlayerController playerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        BulletRB.velocity = transform.right * BulletSpeed;
        Destroy(gameObject, 3);


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        { 
            Destroy(gameObject);

        }

        if (other.CompareTag("platform"))
        {
            Destroy(gameObject);
        }

    }

}
