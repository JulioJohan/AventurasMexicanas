using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefac;
    private Vector3 spawnPos = new Vector3 (25, 0, 0);

    private float startDelay = 2;
    private float repeatRate = 2;

    //Creamos una variable que hacer referencia al palyer
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        //Se inicializa la variable
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefac, spawnPos, obstaclePrefac.transform.rotation);
        }
    }
}
