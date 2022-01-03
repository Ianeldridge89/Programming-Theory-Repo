using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 0;
    public static int waveNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.isGameActive)
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;
            if (enemyCount == 0)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
            }
        }
         

    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(Controller.westRange, Controller.eastRange);
        float spawnPosZ = Random.Range(Controller.southRange, Controller.northRange);
        Vector3 randomPos = new Vector3(spawnPosX, -3, spawnPosZ);
        return randomPos;
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
