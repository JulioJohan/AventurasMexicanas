using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemigoDestructorMundos : MonoBehaviour
{
    // Start is called before the first frame update

    public LogicaBarraVidaPersonajePrincipal logicaBarraVidaPersonajePrincipal;
    public int vidaMax = 100;
    public float vidaActual = 100;
    public Image imagenBarraVida;
    public GameObject imagenMordecai;

    private GameObject personajePrincipal;


  
    void Start()
    {
        personajePrincipal = GameObject.Find("Player");
        vidaActual = vidaMax;
        logicaBarraVidaPersonajePrincipal = GameObject.FindObjectOfType<LogicaBarraVidaPersonajePrincipal>();
    }

    // Update is called once per frame
    void Update()
    {
        seguirPersonaje();
        revisarVida();
        if (vidaActual <= 0)
        {
            logicaBarraVidaPersonajePrincipal.puntos += 100;
            Destroy(gameObject);

            //gameObject.SetActive(false);
        }
    }

    private void seguirPersonaje()
    {
        var buscarPosicion = personajePrincipal.transform.position - transform.position;
        buscarPosicion.y = 0;
        var rotacion = Quaternion.LookRotation(buscarPosicion);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 360);
        //sonidoEfectoCaminar.Stop();
        //sonidoEfectoCaminar.Play();

        transform.Translate(Vector3.forward * 17 * Time.deltaTime);


        if (Vector3.Distance(transform.position, personajePrincipal.transform.position) > 20)
        { 
            //print(Vector3.Distance(transform.position, personajePrincipal.transform.position));
            //efectoRisa.Play();

            //efectoRisa.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LogicaPersonajePrincipal logicaPersonajePrincipal = other.GetComponent<LogicaPersonajePrincipal>();
            print(logicaPersonajePrincipal);

            if (logicaPersonajePrincipal.atacando)
            {
                print("Atacando");
                float danio = 50.0f;
                vidaActual -= danio;
            }
          
        }
    }

    private void revisarVida()
    {

        imagenBarraVida.fillAmount = vidaActual / vidaMax;
        //textoVida.text = vidaActual.ToString();

    }
}
