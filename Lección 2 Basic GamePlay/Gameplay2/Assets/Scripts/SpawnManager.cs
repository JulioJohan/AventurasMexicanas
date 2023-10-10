using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalsPrefabs;
    private float spawnRangeX = 20.0f;
    private float spawnPositionZ = 20.0f;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        //Metodo que repite lo que hace en el metodo que llamamos
        //el intervalo cada cuando
        //el startDelay es cada cuanto
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalsPrefabs.Length);
        Vector3 positionSpawn = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);
        Instantiate(animalsPrefabs[animalIndex], positionSpawn, animalsPrefabs[animalIndex].transform.rotation);
    }
}
