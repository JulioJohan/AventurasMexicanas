using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoKrilin : MonoBehaviour
{

    //Logica para animar el enemigo.
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Rutina del enemigo.
    public void ComportamientoEnemigo()
    {
        /*
      cronometro += *Time.deltaTime;

      if (cronometro >= 4)
      {
          rutina = Random.Range(0, 2);
          cronometro = 0;
      }

      switch (rutina)
      {
          case 0:
              ani.SetBool("walk", false);
              break;
          case 1:
              grado = Random.Range(0, 360);
              angulo= Quaternion.Euler(0, grado, 0);
              rutina++;
              break; 
          case 2:
              transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
              transform.Translate(Vector3.forward * 1 * Time.deltaTime);
              ani.SetBool("walk", true);
      }
      */

    }

}
