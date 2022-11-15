using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveCounter : MonoBehaviour
{

    public float enemiesKilled;
    public float waveNumber;
    public GameObject[] enemyList;
    public PlayerController playerScript;
    public GameObject rocketPickup;
    public GameObject gunPickup;
    public GameObject shieldPickup;
    public GameObject shotGunPickup;
    public GameObject bulletStormPickup;
    public Transform spawnPosition;
    public int frameCounter;

    public GameObject enemyJapan;
    public GameObject enemyBrazil;
    public GameObject enemyKenya;
    public GameObject enemyAustralia;


    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform;
        waveNumber = 1;
        enemiesKilled = 0;
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Instantiate(gunPickup, spawnPosition);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (enemiesKilled >= 50 && waveNumber == 1)
        {
            waveNumber = 2;
            ClearWave();
            Instantiate(rocketPickup, transform);
        }

        if (enemiesKilled >= 100 && waveNumber == 2)
        {
            waveNumber = 3;
            ClearWave();
        }

        if (enemiesKilled >= 150 && waveNumber == 3)
        {
            waveNumber = 4;
            ClearWave();
        }

        if (enemiesKilled >= 200 && waveNumber == 4)
        {
            waveNumber = 5;
            ClearWave();
        }

        if (enemiesKilled >= 250 && waveNumber == 5)
        { 
            ClearWave();
        }


        SpawnEnemiesWave1();

    }

    private void FixedUpdate()
    {
        frameCounter++;
    }

    public void ClearWave()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < enemyList.Length; i++)
            Destroy(enemyList[i]);
    }


    void SpawnEnemiesWave1()
    {
        if (frameCounter > 130 && waveNumber == 1)
        {
            Instantiate(enemyJapan, new Vector3(Random.Range(-15f, +15f), transform.position.x + 10, 0), Quaternion.Euler(0, 0, 0));
            frameCounter = 0;
        }
    }

    void SpawnEnemiesWave2()
    {
        if (frameCounter > 130 && waveNumber == 2)
        {
            Instantiate(enemyJapan, new Vector3(Random.Range(-15f, +15f), transform.position.x + 10, 0), Quaternion.Euler(0, 0, 0));
            frameCounter = 0;
        }
    }
    void SpawnEnemiesWave3()
    {
        if (frameCounter > 130 && waveNumber == 3)
        {
            Instantiate(enemyJapan, new Vector3(Random.Range(-15f, +15f), transform.position.x + 10, 0), Quaternion.Euler(0, 0, 0));
            frameCounter = 0;
        }
    }
    void SpawnEnemiesWave4()
    {
        if (frameCounter > 130 && waveNumber == 4)
        {
            Instantiate(enemyJapan, new Vector3(Random.Range(-15f, +15f), transform.position.x + 10, 0), Quaternion.Euler(0, 0, 0));
            frameCounter = 0;
        }
    }
    void SpawnEnemiesWave5()
    {
        if (frameCounter > 130 && waveNumber == 5)
        {
            Instantiate(enemyJapan, new Vector3(Random.Range(-15f, +15f), transform.position.x + 10, 0), Quaternion.Euler(0, 0, 0));
            frameCounter = 0;
        }
    }

}
