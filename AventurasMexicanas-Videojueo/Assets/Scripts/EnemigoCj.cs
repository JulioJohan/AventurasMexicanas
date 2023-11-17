using UnityEngine;

public class EnemigoCj : MonoBehaviour
{

    //Constantes
    private const string PERSONAJE_PRINCIPAL_OBJECT = "Mordecai";



    // Start is called before the first frame update
    //IA para que el personaje siga al jugador
    public int rutina = 0;
    public float cronometro = 0f;
    public Animator animacion;
    public Quaternion angulo;
    public float grado = 0f;
    public bool atacar;


    //Efectos de Sonido   
    public GameObject efectoCaminar;
    private AudioSource sonidoEfectoCaminar;
    // Start is called before the first frame update

    //Buscar personaje principal
    public GameObject personajePrincipal;
    void Start()
    {
        animacion = GetComponent<Animator>();
        sonidoEfectoCaminar = efectoCaminar.GetComponent<AudioSource>();
        personajePrincipal = GameObject.Find("Mordecai");
        //animacion = GetComponent<Animator>();       
    }

    // Update is called once per frame
    void Update()
    {

        comportamientoEnemigo();
    }

    private void comportamientoEnemigo()
    {
        if(personajePrincipal == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, personajePrincipal.transform.position) > 10)
        {
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 2)
            {
                rutina = Random.Range(0, 3);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    animacion.SetBool("Caminar", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    break;
                case 2:
                    sonidoEfectoCaminar.Stop();
                    sonidoEfectoCaminar.Play();
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 4 * Time.deltaTime);
                    animacion.SetBool("Caminar", true);
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
                sonidoEfectoCaminar.Stop();
                sonidoEfectoCaminar.Play();
                transform.Translate(Vector3.forward * 17 * Time.deltaTime);
                animacion.SetBool("Caminar", true);
            }
            else
            {
                golpearPersonajePrincipal();


            }


        }
    }

    private void golpearPersonajePrincipal()
    {
        animacion.SetBool("Golpear", true);
        animacion.SetBool("Caminar", false);
        atacar = true;
    }

    public void cancelarGolpePersonajePrincipal()
    {
        animacion.SetBool("Golpear", false);
        atacar = false;

    }
  

}
