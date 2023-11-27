using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeleccionarNombre : MonoBehaviour
{
    public TMP_InputField inputField;

    public TextMeshProUGUI textoNombre;

    public Image imagenLuz;

    public GameObject botonAceptar;

    private void Awake()
    {
        imagenLuz.color = Color.red;
    }
    
    private void Update()
    {
        if(textoNombre.text.Length < 4)
        {
            imagenLuz.color = Color.red;
            botonAceptar.SetActive(false);
        }

        if (textoNombre.text.Length >= 4)
        {
            imagenLuz.color = Color.green;
            botonAceptar.SetActive(true);
        }
    }

    public void aceptar()
    {
        PlayerPrefs.SetString("nombreJugador", inputField.text);
        SceneManager.LoadScene("Menu-v2");

        //PlayerPrefs.SetString("nombreJugador");
    }
}
