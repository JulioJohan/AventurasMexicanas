using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 24.0f;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            //Estableciendo la nueva posicion
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        //transform.position = new Vector3(-15, transform.position.y, transform.position.z);
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //Verificamos si el usuario ingresa el boton espacio
        //KeyCode ayuda a identificar el teclado
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate es para que crear objetos como si fueran balas
            // el primer paramtero el el objeto que quiero que cree
            // posicion de donde se creara
            // la rotacion es del objeto
            Instantiate(projectilePrefab,transform.position,projectilePrefab.transform.rotation);
        }


    }
}
