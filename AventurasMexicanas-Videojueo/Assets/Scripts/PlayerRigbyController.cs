using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigbyController : MonoBehaviour
{
    public LogicaBarraVidaPersonajePrincipal logicaBarraVidaPersonajePrincipal;

    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator playerAnim;
    public float x, y;

    public Rigidbody rb;
    public float fuerzaSalto = 8f;
    public bool puedoSaltar;

    //Variable para la animacion de bailar.
    private float tiempoInactivo;

    //Variable saber si esta atacando
    private bool atacando;


    //Animación
    private int inactivo;

    private int tipoEspada;

    //Vida del personaje
    public float vidaPersonaje;

    //Base de datos
    private BaseDatos baseDatos;

    //Variable para saber si sigue jugando.
    private bool jugando;

    //Canvas
    public GameObject finDelJuegoCanvas;

    private string nombreJugador;


    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        playerAnim = gameObject.GetComponent<Animator>();
        tiempoInactivo = 0f;

        vidaPersonaje = logicaBarraVidaPersonajePrincipal.vidaActual;
        //Inicializando varible
        jugando = true;
        nombreJugador = PlayerPrefs.GetString("nombreJugador");


    }

    void FixedUpdate()
    {
        if (!atacando)
        {
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
            //Ajustando la rotacion
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
    
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Obtener las entradas del teclado
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        //Aplicando animacion.
        // Si el personaje está en movimiento
        if (x != 0 || y != 0)
        {
            //Generando animacion aleatoria.
            inactivo = Random.Range(1, 5);
            Debug.Log(inactivo + " generado");

            tiempoInactivo = 0f; // Restablecer el tiempo de inactividad
            playerAnim.SetFloat("tiempoInactivo", tiempoInactivo);
        }
        else
        {
            tiempoInactivo += Time.deltaTime; // Incrementar el tiempo de inactividad
            playerAnim.SetFloat("tiempoInactivo", tiempoInactivo);
            playerAnim.SetInteger("inactivo", inactivo);
        }

        playerAnim.SetFloat("VelX", x);
        playerAnim.SetFloat("VelY", y);

        if (puedoSaltar)
        {
            if (!atacando)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    playerAnim.SetBool("salte", true);
                    rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                }
            }
            playerAnim.SetBool("tocoSuelo", true);

        }
        else
        {
            estoyCayendo();
        }

        // Detectar el clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0) && puedoSaltar && !atacando)
        {
            //tiempoAtaque += Time.deltaTime; // Incrementar el tiempo de inactividad
            tiempoInactivo = 0f; // Restablecer el tiempo de inactividad

            // Seteando variables al animator
            playerAnim.SetInteger("tipoEspada", tipoEspada);
            playerAnim.SetTrigger("golpeo");
            atacando = true;
        }
    }

    public void estoyCayendo()
    {
        playerAnim.SetBool("tocoSuelo", false);
        playerAnim.SetBool("salte", false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("poder"))
        {
            print("recibiendo daño");
            float danio = 10.0f;
            logicaBarraVidaPersonajePrincipal.vidaActual -= danio;
            vidaPersonaje = logicaBarraVidaPersonajePrincipal.vidaActual;
        }
        if (other.CompareTag("vida"))
        {
            float vida = 30.0f;
            logicaBarraVidaPersonajePrincipal.vidaActual += vida;
            vidaPersonaje = logicaBarraVidaPersonajePrincipal.vidaActual;

            print("Sumando vida");
        }

        if (vidaPersonaje <= 0)
        {
            baseDatos.guardarPuntosBaseDatos(logicaBarraVidaPersonajePrincipal.puntos, nombreJugador);
            jugando = false;
            verificarJugando();
            Destroy(other.gameObject);

            finDelJuegoCanvas.SetActive(true);
        }
    }

    private void verificarJugando()
    {
        if (!jugando)
        {
            //musicaFondoFin.Play();
            //musicaFondo.Stop();
        }
        if (jugando)
        {

            //musicaFondoFin.Stop();
        }
    }


    public void DejoAtacar()
    {
        atacando=false;

    }

    public void TomoEspada(int tipoEspadaT)
    {
        playerAnim.SetTrigger("tomoEspada");
        tipoEspada = tipoEspadaT;
    }
}
