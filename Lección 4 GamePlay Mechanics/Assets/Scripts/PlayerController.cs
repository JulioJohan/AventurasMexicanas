using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigiBody;
    //Objeto donde esta la camara
    private GameObject focalPoint;
    private bool powerUp = false;
    private float powerUpStrength = 15.0f;
    public float speed = 5.0f;
    public GameObject powerUpIndicator;
    void Start()
    {
        playerRigiBody = GetComponent<Rigidbody>();
        //Cuando inicie, buscara el objeto del hirence
        focalPoint = GameObject.Find("FocalPoint");

    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        //Agregando fuerza al jugador
        //Agregando donde sigue el jugador con las teclas
        //Usa la direccion del focopoint
        playerRigiBody.AddForce(focalPoint.transform.forward * speed * forwardInput );
        //Establecer la posicion del objeto
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            //Se activa el PowerUp
            powerUp = true;
            //Eliminar el objeto
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCoutdownRountine());
            powerUpIndicator.gameObject.SetActive(true);
        }
    }

    //Checa si despues de los 7 segundos se desactiva el poder
    IEnumerator PowerUpCoutdownRountine()
    {
        yield return new WaitForSeconds(7);
        powerUp = false;
        powerUpIndicator.SetActive(false);
    }

    //Si tiene power up y choca con el enemy 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && powerUp)
        {
            //Obtenemos el Rigidbody para agregar fuerza
            Rigidbody enemyRigiBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

           //Agregando fuerza 
            enemyRigiBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
