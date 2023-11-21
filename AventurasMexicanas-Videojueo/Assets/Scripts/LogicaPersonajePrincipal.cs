using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonajePrincipal : MonoBehaviour
{
    public LogicaBarraVidaPersonajePrincipal logicaBarraVidaPersonajePrincipal;
    private BaseDatos baseDatos;
    public float velocidadMovimiento = 10.0f;
    public float velocidadRotacion = 200.0f;
    private Animator animator;
    public float horizontal = 0.0f;
    public float vertical = 0.0f;

    public Rigidbody rigidbody;

    //Rigibody, golpe
    public bool atacando;
    public bool avanzoSolo;
    public float impulsoDeGolpe = 10.0f;

    public GameObject finDelJuegoCanvas; 


    public float vidaPersonaje;
    public EventHandler muerteJugador;

    //Sonidos
    public GameObject efectoDanio;
    private AudioSource sonidoEfectoDanio;

    private bool jugando; 

    //Fondo
    public GameObject musicaFondoGameObject;
    private AudioSource musicaFondo;

    //Fondo Final del Juego
    public GameObject musicaFondoFinGameObject;
    private AudioSource musicaFondoFin;

    // Start is called before the first frame update


    void Start()
    {

        baseDatos = GameObject.FindObjectOfType<BaseDatos>();
        rigidbody = GetComponent<Rigidbody>();
        // Establece isKinematic en true para evitar la influencia de la física externa
        sonidoEfectoDanio = efectoDanio.GetComponent<AudioSource>();
        musicaFondo =  musicaFondoGameObject.GetComponent<AudioSource>();
        musicaFondoFin = musicaFondoFinGameObject.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        vidaPersonaje = logicaBarraVidaPersonajePrincipal.vidaActual;
        jugando = true;
        musicaFondo.Play();
    }

    // Update is called once per frame
    void Update()
    {

        movimientoPersonaje();
        checarFueraJugador();
        //verificarJugando();
        golpe();
    }

    public void golpe()
    {

        if (avanzoSolo)
        {
            rigidbody.velocity = transform.forward * impulsoDeGolpe;
        }

        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("golpe");
            atacando = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PunosCJ"))
        {

            float danio = 10.0f;    
            logicaBarraVidaPersonajePrincipal.vidaActual -= danio;
            vidaPersonaje = logicaBarraVidaPersonajePrincipal.vidaActual;

            //Quitar IF cuando se 

                sonidoEfectoDanio.Pause();
                sonidoEfectoDanio.Play();                               
        }

        if (other.CompareTag("DestructorMundos"))
        {
            float danio = 20.0f;
            logicaBarraVidaPersonajePrincipal.vidaActual -= danio;
            vidaPersonaje = logicaBarraVidaPersonajePrincipal.vidaActual;            
        }
        if (vidaPersonaje <= 0)
        {
            baseDatos.guardarPuntosBaseDatos(logicaBarraVidaPersonajePrincipal.puntos);
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
            musicaFondoFin.Play();
            musicaFondo.Stop();
        }
        if (jugando)
        {

            musicaFondoFin.Stop();
        }
    }

    private void movimientoPersonaje()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Rotate(0, horizontal * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, vertical * Time.deltaTime * velocidadMovimiento);
        animator.SetFloat("velocidadHorizontal", horizontal);
        animator.SetFloat("velocidadVertical", vertical);       
    }

    public void dejoGolpear()
    {
        atacando = false;
        avanzoSolo = false;
        print(atacando);
    }

    public void avanzoSoloMetodo ()
    {
            avanzoSolo = true;
    }

    public void dejoDeAvanzar() 
    {
        avanzoSolo = false;
    }

    private void checarFueraJugador()
    {
        if (gameObject.transform.position.y <= -5)
        {
            finDelJuegoCanvas.SetActive(true);
            baseDatos.guardarPuntosBaseDatos(logicaBarraVidaPersonajePrincipal.puntos);
            transform.position = new Vector3(0, 0, 0);

        }
    }
}
