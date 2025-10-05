using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Enemy Prefabs Array")]
    [SerializeField] GameObject[] enemyPrefabs;

    [Header("Powerup Prefabs Array")]
    [SerializeField] GameObject[] powerupPrefabs;

    [Header("Enemy Number")]
    [SerializeField] int enemyCount;
    [SerializeField] int waveNumber = 1;
    [SerializeField] float pointPosition = 9;

    

    private void Start()
    {
        SpawnEnemyWave(waveNumber);
        int powerUpPrefabsIndex = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[powerUpPrefabsIndex], Spawn(), powerupPrefabs[powerUpPrefabsIndex].transform.rotation);
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            int powerUpPrefabsIndex = Random.Range(0, powerupPrefabs.Length);

            Instantiate(powerupPrefabs[powerUpPrefabsIndex], Spawn(), powerupPrefabs[powerUpPrefabsIndex].transform.rotation);
        }

       
    }

    void SpawnEnemyWave(int enemyToSpwn)
    {
        int enemyPrefabsIndex = Random.Range(0, enemyPrefabs.Length);

        for (int i = 0; i < enemyToSpwn; i++)
        {
            Instantiate(enemyPrefabs[enemyPrefabsIndex], Spawn(), enemyPrefabs[enemyPrefabsIndex].transform.rotation);
        }
    }

    Vector3 Spawn()
    {
        float pointX = Random.Range(-pointPosition, pointPosition);
        float pointZ = Random.Range(-pointPosition, pointPosition);

        Vector3 position = new Vector3(pointX, 0, pointZ);

        return position;
 
    }

}
