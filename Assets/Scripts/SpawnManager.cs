using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject powerupPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int powerupCount;
    public int waveNumber=1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GeneratwSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount==0)
        {            
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GeneratwSpawnPosition(), powerupPrefab.transform.rotation);
        }

    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        var enemyIndex = Random.Range(0,enemyCount);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs[enemyIndex], GeneratwSpawnPosition(), enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
    private Vector3 GeneratwSpawnPosition()
    {
        var spawnPosX = Random.Range(-spawnRange, spawnRange);
        var spawnPosZ = Random.Range(-spawnRange, spawnRange);

        var randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }



}
