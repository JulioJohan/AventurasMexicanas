using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamearEnemigosNivel1 : MonoBehaviour
{
    public GameObject jefeFinal;
    public GameObject enemigo;
    public GameObject vida;
    public GameObject escena;

    private float spawnearRangeX = 40;
    private float spawnearZMin = 15; // set min spawn Z
    private float spawnearZMax = 40; // set max spawn Z

    public int enemigoTotal = 0;
    public int jefeTotal = 0;

    public int waveCount = 1;
    public int enemySpeed = 50;

    public int cantidadJefes = 1;

    public Transform jugador; // referencia al jugador

    // Start is called before the first frame update
    void Start()
    {
    }

    Vector3 GenerarSpawnPosicionCercaJugador()
    {
        float distancia = 10.0f; // distancia desde el jugador donde el enemigo puede aparecer
        Vector3 posicionJugador = jugador.position; // obtén la posición del jugador

        // genera una posición alrededor del jugador
        float xPos = posicionJugador.x + Random.Range(-distancia, distancia);
        float zPos = posicionJugador.z + Random.Range(-distancia, distancia);

        return new Vector3(xPos, 0, zPos);
    }

    private void checarEnemigos()
    {

        enemigoTotal = GameObject.FindGameObjectsWithTag("krilin").Length;
        //jefeTotal = GameObject.FindGameObjectsWithTag("DestructorMundos").Length;

        print("enemigoTotal"+ enemigoTotal);
        print("waveCount" + waveCount);
        if (enemigoTotal == 0 )
        {
            waveCount++;
            waveCount++;

            SpawnearEnemigoYVida(waveCount);
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
            Instantiate(enemigo, GenerarSpawnPosicionCercaJugador(), enemigo.transform.rotation);
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
