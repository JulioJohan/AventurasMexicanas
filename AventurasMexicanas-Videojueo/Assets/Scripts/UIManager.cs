using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{
    public GameObject botonesMovil;
    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_ANDROID || UNITY_IOS
                // Mostrar los botones en plataformas móviles
                botonesMovil.SetActive(true);
        #else
                // Ocultar los botones en otras plataformas
                botonesMovil.SetActive(false);
                botonesMovil.SetActive(false);
                // Haz lo mismo para cualquier otro botón
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
