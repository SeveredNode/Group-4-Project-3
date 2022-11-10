using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController: MonoBehaviour
{
    public float BulletSpeed;
    public Rigidbody2D RocketRB;
    public PlayerController playerScript;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        RocketRB.velocity = transform.right * BulletSpeed;
        Destroy(gameObject, 5);


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.CompareTag("platform"))
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }

    }

}
