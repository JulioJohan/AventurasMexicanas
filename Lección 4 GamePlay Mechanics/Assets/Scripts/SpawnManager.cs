using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount = 0;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {

        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab, generateSpawnPosition(),powerUpPrefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        ///Verficamos cuantos enemigos existen
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            //si es igual a 0 aparecera
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, generateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, generateSpawnPosition(), enemyPrefab.transform.rotation);
        }

    }

    private Vector3 generateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPosition = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPosition;
    }

   
}
