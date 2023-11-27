using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool atacando;


    //Animaci�n
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

    //Joystic
    public Joystick joystick;

    public Button botonGolpeo; //  usando UnityEngine.UI;
    private bool botonGolpeoPresionado = false;

    public Button botonSalto; //  usando UnityEngine.UI;
    private bool botonSaltoPresionado = false;
    private string nombreJugador;

    public AudioSource musicaFondo;

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

        botonGolpeo.onClick.AddListener(() => botonGolpeoPresionado = true);
        botonSalto.onClick.AddListener(() => botonSaltoPresionado = true);

        baseDatos = GameObject.FindObjectOfType<BaseDatos>();


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
        #if UNITY_ANDROID || UNITY_IOS
                x = joystick.Horizontal * 1.2f;
                y = joystick.Vertical * 1.2f;
        #else
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        #endif

        //Aplicando animacion.
        // Si el personaje est� en movimiento
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
                #if UNITY_ANDROID || UNITY_IOS
                                // Detectar si el bot�n de golpeo ha sido presionado
                                if (botonSaltoPresionado)
                                {
                                    botonSaltoPresionado = false; // Restablecer el estado del bot�n

                                    playerAnim.SetBool("salte", true);
                                    rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                                }
                #else
                               if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    playerAnim.SetBool("salte", true);
                                    rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                                }
                #endif

            }
            playerAnim.SetBool("tocoSuelo", true);

        }
        else
        {
            estoyCayendo();
        }

        #if UNITY_ANDROID || UNITY_IOS
                // Detectar si el bot�n de golpeo ha sido presionado
                if (botonGolpeoPresionado && puedoSaltar && !atacando)
                {
                    botonGolpeoPresionado = false; // Restablecer el estado del bot�n
                    tiempoInactivo = 0f; // Restablecer el tiempo de inactividad

                    // Seteando variables al animator
                    playerAnim.SetInteger("tipoEspada", tipoEspada);
                    playerAnim.SetTrigger("golpeo");
                    atacando = true;
                }
        #else
                // Detectar el clic izquierdo del mouse
                if (Input.GetMouseButtonDown(0) && puedoSaltar && !atacando)
                {
                    tiempoInactivo = 0f; // Restablecer el tiempo de inactividad

                    // Seteando variables al animator
                    playerAnim.SetInteger("tipoEspada", tipoEspada);
                    playerAnim.SetTrigger("golpeo");
                    atacando = true;
                }
        #endif

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
            print("recibiendo da�o");
            float danio = 10.0f;
            logicaBarraVidaPersonajePrincipal.vidaActual -= danio;
            vidaPersonaje = logicaBarraVidaPersonajePrincipal.vidaActual;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("vida"))
        {
            float vida = 30.0f;
            logicaBarraVidaPersonajePrincipal.vidaActual += vida;
            vidaPersonaje = logicaBarraVidaPersonajePrincipal.vidaActual;

            print("Sumando vida");
        }

        if (vidaPersonaje <= 0 && jugando)
        {
            jugando = false;
            verificarJugando();
            Destroy(other.gameObject);

            musicaFondo.Stop();

            finDelJuegoCanvas.SetActive(true);
            baseDatos.guardarPuntosBaseDatos(logicaBarraVidaPersonajePrincipal.puntos, nombreJugador);

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
