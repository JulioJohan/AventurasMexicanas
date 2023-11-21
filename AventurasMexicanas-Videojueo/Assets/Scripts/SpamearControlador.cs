using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamearControlador : MonoBehaviour
{

    public GameObject jefeFinal;
    public GameObject enemigo;
    public GameObject vida;
    public GameObject escena;

    private float spawnearRangeX = 80;
    private float spawnearZMin = 15; // set min spawn Z
    private float spawnearZMax = 80; // set max spawn Z

    public int enemigoTotal = 0;
    public int jefeTotal = 0;

    public int waveCount = 1;
    public int enemySpeed = 50;

    public int cantidadJefes = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void checarEnemigos()
    {

        enemigoTotal = GameObject.FindGameObjectsWithTag("CJ").Length;
        jefeTotal = GameObject.FindGameObjectsWithTag("DestructorMundos").Length;

        //print("enemigoTotal"+ enemigoTotal);
        //print("waveCount" + waveCount);
        if (enemigoTotal == 0 && jefeTotal == 0)
        {
            waveCount++;
            SpawnearEnemigoYVida(waveCount);
        }


        if (jefeTotal == 0 && waveCount >= 3 && enemigoTotal == 0) {
            cantidadJefes += 1;
            SpawnearJefeYVida(cantidadJefes);
            if (cantidadJefes ==1)
            {
                escena.SetActive(true);
            }
        }
    }

    Vector3 GenerarSpawnPosicion()
    {
        float xPos = Random.Range(-spawnearRangeX, spawnearRangeX);
        float zPos = Random.Range(spawnearZMin, spawnearZMax);
        return new Vector3(xPos, 0, zPos);
    }
    Vector3 GenerarSpawnJefePosicion()
    {
        float xPos = Random.Range(-spawnearRangeX, spawnearRangeX);
        float zPos = Random.Range(spawnearZMin, spawnearZMax);
        return new Vector3(xPos, 3, zPos);
    }


    void SpawnearEnemigoYVida(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

        // If no powerups remain, spawn a powerup
      if (GameObject.FindGameObjectsWithTag("vida").Length == 0) // check that there are zero powerups
      {
          Instantiate(vida, GenerarSpawnPosicion() + powerupSpawnOffset, vida.transform.rotation);
          Instantiate(vida, GenerarSpawnPosicion() + powerupSpawnOffset, vida.transform.rotation);
          Instantiate(vida, GenerarSpawnPosicion() + powerupSpawnOffset, vida.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
       {
          Instantiate(enemigo, GenerarSpawnPosicion(), enemigo.transform.rotation);
       }
        //enemySpeed += 25;
        //ResetPlayerPosition(); // put player back at start

    }

    private void SpawnearJefeYVida(int cantidaJefes)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

       // Instantiate(vida, GenerarSpawnPosicion() + powerupSpawnOffset, vida.transform.rotation);
       // Instantiate(vida, GenerarSpawnPosicion() + powerupSpawnOffset, vida.transform.rotation);

        for (int i = 0; i < cantidaJefes; i++)
        {
            Instantiate(jefeFinal, GenerarSpawnJefePosicion(), enemigo.transform.rotation);
        }
    }



    // Update is called once per frame
    void Update()
    {
        checarEnemigos();

    }
}
