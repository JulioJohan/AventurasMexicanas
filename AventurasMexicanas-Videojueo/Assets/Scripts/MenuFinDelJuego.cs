using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinDelJuego : MonoBehaviour
{
    // Start is called before the first frame update

    private LogicaPersonajePrincipal logicaPersonajePrincipal;
    void Start()
    {
        logicaPersonajePrincipal = GetComponent<LogicaPersonajePrincipal>();
    }


    // Update is called once per frame
    void Update()
    {
        //activarMenu();
    }
    private void activarMenu()
    {
        if (logicaPersonajePrincipal.vidaPersonaje <= 0)
        {
            gameObject.SetActive(true);
        }
    }
    public void reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
