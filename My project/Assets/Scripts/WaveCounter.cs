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

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform;
        waveNumber = 1;
        enemiesKilled = 0;
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Instantiate(gunPickup, spawnPosition);
        SpawnEnemiesWave1();
    }

    // Update is called once per frame
    void Update()
    {

        if (enemiesKilled >= 5 && waveNumber == 1)
        {
            waveNumber = 2;
            ClearWave();
            Instantiate(rocketPickup, transform);
        }

        if (enemiesKilled >= 30 && waveNumber == 2)
        {
            waveNumber = 3;
            ClearWave();
        }

        if (enemiesKilled >= 50 && waveNumber == 3)
        {
            waveNumber = 4;
            ClearWave();
        }

        if (enemiesKilled >= 70 && waveNumber == 4)
        {
            waveNumber = 5;
            ClearWave();
        }

        if (enemiesKilled >= 100 && waveNumber == 5)
        { 
            ClearWave();
        }




    }

    public void ClearWave()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < enemyList.Length; i++)
            Destroy(enemyList[i]);
    }


    void SpawnEnemiesWave1()
    {

    }


}
