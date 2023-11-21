using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarPiano : MonoBehaviour
{
    public float velocidadDeRotacion = 50f; // Velocidad de rotaci�n en grados por segundo
    public float amplitud = 0.5f; // Amplitud del movimiento de flotaci�n
    public float velocidadDeFlotacion = 1f; // Velocidad del movimiento de flotaci�n

    private Vector3 posicionInicial;

    //Aumentar la vida
    public LogicaBarraVidaPersonajePrincipal logicaBarraVidaPersonajePrincipal;


    void Start()
    {
        // Guardar la posici�n inicial
        posicionInicial = transform.position;
        // Establecer la altura inicial en el eje Y a 2
        posicionInicial.y = 2;
        transform.position = posicionInicial;

        logicaBarraVidaPersonajePrincipal = GameObject.FindObjectOfType<LogicaBarraVidaPersonajePrincipal>();

    }

    void Update()
    {
        // Rotar la moneda alrededor del eje Y
        transform.Rotate(Vector3.up, velocidadDeRotacion * Time.deltaTime);

        // Mover la moneda arriba y abajo
        transform.position = posicionInicial + Vector3.up * amplitud * Mathf.Sin(Time.time * velocidadDeFlotacion);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            logicaBarraVidaPersonajePrincipal.vidaActual += 20;
            Destroy(gameObject);
        }
    }
}
