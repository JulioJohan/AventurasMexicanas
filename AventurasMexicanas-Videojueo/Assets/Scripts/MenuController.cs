using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void salir()
    {
        //Se utiliza cerrar de la aplicacion.
        Application.Quit();
    }

    public void CargarNivel(string nivel)
    {
        //Se usa para cargar una esena, se le pasa el nombre de la imagen
        SceneManager.LoadScene(nivel);
    }

}
