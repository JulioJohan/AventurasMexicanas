using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigbyController : MonoBehaviour
{

    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator playerAnim;
    public float x, y;

    public Rigidbody rb;
    public float fuerzaSalto = 8f;
    public bool puedoSaltar;

    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        playerAnim = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        //Ajustando la rotacion
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener las entradas del teclado
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        playerAnim.SetFloat("VelX", x);
        playerAnim.SetFloat("VelY", y);

        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnim.SetBool("salte", true);
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            }
            playerAnim.SetBool("tocoSuelo", true);

        }
        else
        {
            estoyCayendo();
        }


    }

    public void estoyCayendo()
    {
        playerAnim.SetBool("tocoSuelo", false);
        playerAnim.SetBool("salte", false);
    }
}
