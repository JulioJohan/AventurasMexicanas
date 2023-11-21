using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBarraVidaPersonajePrincipal : MonoBehaviour
{
    // Start is called before the first frame update

    public int vidaMax = 100;
    public float vidaActual = 100;
    public Image imagenBarraVida;
    public Text textoVida;
    public TextMeshProUGUI textoPuntos;
    public int puntos = 0;
    void Start()
    {
        vidaActual = vidaMax;
        textoPuntos.text  = puntos.ToString();
    }

    // Update is called once per frame
    void Update()
    {


        revisarVida();
        checarPuntos();


    }

    private void checarPuntos()
    {
        textoPuntos.text = puntos.ToString();
    }

    private void revisarVida()
    {
        imagenBarraVida.fillAmount = vidaActual / vidaMax;
        textoVida.text = vidaActual.ToString();

    }
}
