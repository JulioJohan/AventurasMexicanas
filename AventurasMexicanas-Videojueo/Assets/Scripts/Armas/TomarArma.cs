using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarArma : MonoBehaviour
{

    public GameObject[] armas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activarArmas(int numero) { 
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }
        armas[numero].SetActive(true);
    }

    public void desactivarArmas()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < armas.Length; i++)
            {
                armas[i].SetActive(false);
            }
        }
       
    }
}
