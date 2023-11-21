using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LogicaVidaEnemigoCj : MonoBehaviour
{
    // Start is called before the first frame update
    public LogicaBarraVidaPersonajePrincipal logicaBarraVidaPersonajePrincipal;
    public int vidaMax = 100;
    public float vidaActual = 100;
    public Image imagenBarraVida;

    public GameObject imagenMordecai;

    public GameObject efectoPuntosObjeto;
    private AudioSource efectoPuntos;

    //public Text textoVida;
    public int puntos;
    void Start()
    {
        vidaActual = vidaMax;
        logicaBarraVidaPersonajePrincipal = GameObject.FindObjectOfType<LogicaBarraVidaPersonajePrincipal>();       
        print(imagenMordecai);
    }

    // Update is called once per frame
    void Update()
    {

        revisarVida();
        if (vidaActual <= 0)
        {
            logicaBarraVidaPersonajePrincipal.puntos += 30;
            Destroy(gameObject);

            //gameObject.SetActive(false);
        }

    }

    private void revisarVida()
    {

        imagenBarraVida.fillAmount = vidaActual / vidaMax;
        //textoVida.text = vidaActual.ToString();

    }


}
