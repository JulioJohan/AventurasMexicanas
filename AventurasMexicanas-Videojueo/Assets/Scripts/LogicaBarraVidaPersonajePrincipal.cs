using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBarraVidaPersonajePrincipal : MonoBehaviour
{
    // Start is called before the first frame update

    public int vidaMax = 100;
    public float vidaActual = 100;
    public Image imagenBarraVida;
    public Text textoVida;
    void Start()
    {
        vidaActual = vidaMax;   
    }

    // Update is called once per frame
    void Update()
    {

        revisarVida();
        if (vidaActual <= 0)
        {  
            //Destroy(gameObject);
            //gameObject.SetActive(false);
        }
        
    }

    private void revisarVida()
    {
        imagenBarraVida.fillAmount = vidaActual / vidaMax;
        textoVida.text = vidaActual.ToString();

    }
}
