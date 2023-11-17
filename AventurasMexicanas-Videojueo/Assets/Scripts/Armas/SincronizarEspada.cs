using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SincronizarEspada : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform personajeTransform; // Asigna el Transform del personaje en el Inspector.

    void Start()
    {
        transform.position = personajeTransform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
