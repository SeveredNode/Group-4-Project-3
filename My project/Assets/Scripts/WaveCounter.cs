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

    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 1;
        enemiesKilled = 0;
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

        if (enemiesKilled >= 10 && waveNumber == 1)
        {
            waveNumber = 2;
            ClearWave();

        }

        if (enemiesKilled >= 30 && waveNumber == 2)
        {
            waveNumber = 3;
            //UI UpgradeScreen

            ClearWave();
            

        }

        if (enemiesKilled >= 50 && waveNumber == 3)
        {
            waveNumber = 4;
            //UI UpgradeScreen

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
            //SceneManager.LoadScene("Credits");
        }




    }

    public void ClearWave()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < enemyList.Length; i++)
            Destroy(enemyList[i]);
    }

}
