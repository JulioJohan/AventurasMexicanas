using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }  
    //Metodo para eliminar los personajes con el arma
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        //Elimina los personajes
        Destroy(other.gameObject);
    }
}
