using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPoder : MonoBehaviour
{

    public float speed = 40.0f;
    private Rigidbody poder;
    private GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        poder = GetComponent<Rigidbody>();
        jugador = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {     
        Vector3 buscarDireccion = ((jugador.transform.position - transform.position).normalized * speed) ;
        poder.AddForce(buscarDireccion);
    }

}
