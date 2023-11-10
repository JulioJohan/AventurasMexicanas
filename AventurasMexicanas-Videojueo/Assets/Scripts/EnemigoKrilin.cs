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

    public bool atacar;

    public GameObject personajePrincipal;


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        atacar = false;
        personajePrincipal = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        ComportamientoEnemigo();
    }

    //Rutina del enemigo.
    public void ComportamientoEnemigo()
    {
        if (Vector3.Distance(transform.position, personajePrincipal.transform.position) > 10)
        {
            ani.SetBool("Correr", false);
            ani.SetBool("Golpear", false);
            atacar = false;

            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("Caminar", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 4 * Time.deltaTime);
                    ani.SetBool("Caminar", true);
                    break;
            }
        }
        else
        {

            if (Vector3.Distance(transform.position, personajePrincipal.transform.position) > 1 && !atacar)
            {
                var buscarPosicion = personajePrincipal.transform.position - transform.position;
                buscarPosicion.y = 0;
                var rotacion = Quaternion.LookRotation(buscarPosicion);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 360);

                ani.SetBool("Caminar", false);


                ani.SetBool("Correr", true);


                transform.Translate(Vector3.forward * 6 * Time.deltaTime);

                ani.SetBool("Golpear", false);


            }
            else
            {
                ani.SetBool("Caminar", false);
                ani.SetBool("Correr", false);

                ani.SetBool("Golpear", true);
                atacar = true;
            }


        }

    }

}
