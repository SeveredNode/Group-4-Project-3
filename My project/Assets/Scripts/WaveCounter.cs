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
    public GameObject enemySpain;

    bool spawnedItemsWave1;
    bool spawnedItemsWave2;
    bool spawnedItemsWave3;
    bool spawnedItemsWave4;



    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform;
        waveNumber = 1;
        enemiesKilled = 0;
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnedItemsWave1 = false;
        spawnedItemsWave2 = false;
        spawnedItemsWave3 = false;
        spawnedItemsWave4 = false;


    }

    // Update is called once per frame
    void Update()
    {


        CountWaves();

        SpawnEnemiesWave1();
        SpawnEnemiesWave2();
        SpawnEnemiesWave3();
        SpawnEnemiesWave4();
        SpawnEnemiesWave5();
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
        
        if (frameCounter > 140 && waveNumber == 1)
        {
            Instantiate(enemyJapan, new Vector3(Random.Range(-15f, +15f), transform.position.x + 15, 0), Quaternion.Euler(0, 0, 0));
            frameCounter = 0;

            

        }

        if (spawnedItemsWave1 == false)
        {
            Instantiate(gunPickup, transform);
            spawnedItemsWave1 = true;
        }

    }

    void SpawnEnemiesWave2()
    {
        
        if (frameCounter > 110 && waveNumber == 2)
        {
            Instantiate(enemyAustralia, new Vector3(Random.Range(-15f, +15f), transform.position.x + 15, 0), Quaternion.Euler(0, 0, 0));
            frameCounter = 0;

           

        }

        if (spawnedItemsWave2 == false && waveNumber == 2)
        {
            Instantiate(shotGunPickup, transform);
            spawnedItemsWave2 = true;
        }

    }
    void SpawnEnemiesWave3()
    {
        
        if (frameCounter > 90 && waveNumber == 3)
        {
            Instantiate(enemyBrazil, new Vector3(Random.Range(-15f, +15f), transform.position.x + 15, 0), Quaternion.Euler(0, 0, 0));
            frameCounter = 0;

            

        }

        if (spawnedItemsWave3 == false && waveNumber == 3)
        {
            Instantiate(shieldPickup, transform);
            Instantiate(rocketPickup, new Vector3(transform.position.x, transform.position.y + 8, 0), Quaternion.Euler(0, 0, 0));
            spawnedItemsWave3 = true;
        }

    }
    void SpawnEnemiesWave4()
    {
        
        if (frameCounter > 90 && waveNumber == 4)
        {
            Instantiate(enemyKenya, new Vector3(Random.Range(-15f, +15f), transform.position.x + 15, 0), Quaternion.Euler(0, 0, 0));
            frameCounter = 0;
        }

        if (spawnedItemsWave4 == false && waveNumber == 4)
        {
            Instantiate(bulletStormPickup, transform);
            spawnedItemsWave4 = true;
        }

    }
    void SpawnEnemiesWave5()
    {
        
        if (frameCounter > 60 && waveNumber == 5)
        {
            Instantiate(enemySpain, new Vector3(Random.Range(-15f, +15f), transform.position.x + 15, 0), Quaternion.Euler(0, 0, 0));
            frameCounter = 0;
        }
    }


    void CountWaves()
    {
        if (enemiesKilled >= 15 && waveNumber == 1)
        {
            waveNumber = 2;
            ClearWave();
            playerScript.health = playerScript.maxHealth;
        }

        if (enemiesKilled >= 35 && waveNumber == 2)
        {
            waveNumber = 3;
            ClearWave();
            playerScript.health = playerScript.maxHealth;
        }

        if (enemiesKilled >= 55 && waveNumber == 3)
        {
            waveNumber = 4;
            ClearWave();
            playerScript.health = playerScript.maxHealth;
        }

        if (enemiesKilled >= 75 && waveNumber == 4)
        {
            waveNumber = 5;
            ClearWave();
            playerScript.health = playerScript.maxHealth;
        }

        if (enemiesKilled >= 100 && waveNumber == 5)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

}
