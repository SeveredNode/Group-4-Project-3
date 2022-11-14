using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D RB;
    public float bulletSpeed;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        RB = GetComponent<Rigidbody2D>();

        Vector3 fireDirection = player.transform.position - transform.position;

        RB.velocity = new Vector2(fireDirection.x, fireDirection.y).normalized * bulletSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3);
    }
}
