using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmas : MonoBehaviour
{
    private TomarArma tomarArma;
    public int numeroArma;
    // Start is called before the first frame update
    void Start()
    {
        tomarArma = GameObject.FindGameObjectWithTag("Mordecai").GetComponent<TomarArma>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.CompareTag("Mordecai")) {
            print(numeroArma);
            tomarArma.activarArmas(numeroArma);
            Destroy(gameObject);   
        }
    }
}
