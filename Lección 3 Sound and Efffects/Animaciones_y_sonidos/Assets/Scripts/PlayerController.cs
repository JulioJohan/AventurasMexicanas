using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Se crea una referencia al rigidbody
    private Rigidbody playerRb;
    //Se crea una referencia al animator
    private Animator playerAnim;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    //Variable para saber cuando perdio el jugador
    public bool gameOver;

    //Variable para el control de la explosion
    public ParticleSystem explosionParticle;
    //Variable para el control de las particulas
    public ParticleSystem dirtParticle;

    //Variable para hacer referncia a un archivo de audio de saltar
    public AudioClip jumpSound;
    //Variable para hacer referncia a un archivo de audio de caida
    public AudioClip crashSound;

    //Componente de audio
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        //Inicializando el animator
        playerAnim = GetComponent<Animator>();
        //Inicializando la variable de player audio.
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Se valida si se esta pulsando la tecla de espacio
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            //Se aplican fisicas para saltar al personaje
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //Solamente podra saltar cuando este en el suelo
            isOnGround = false;
            //Agregando la animacion de saltar.
            playerAnim.SetTrigger("Jump_trig");
            //Manejando la animacion de la particula
            dirtParticle.Stop();
            //Reproduciendo el audio de saltar.
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Se valida el tipo de colisicon. Para que funcione se debe de agregar a una etiqueta.
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            //Manejando la animacion de la particula
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            //Manejando la animacion de la particula
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);

        }

    }
}
