using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigbyController : MonoBehaviour
{
    private Animator playerAnim;

    public float velocidad = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener las entradas del teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        //if (Input.GetKeyDown(KeyCode))
        //{
            //Agregando la animacion de saltar.
          //playerAnim.SetTrigger("Jump_trig");
        //}

        // Calcular el vector de movimiento
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical) * velocidad;

        // Aplicar el movimiento al personaje
        transform.Translate(movimiento * Time.deltaTime);

    }
}
