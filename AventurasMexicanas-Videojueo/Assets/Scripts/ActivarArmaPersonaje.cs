using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmaPersonaje : MonoBehaviour
{
    public LogicaTomarArma logicaTomarArma;

    //Variable para rigby
    public PlayerRigbyController playerRigbyController;

    public int numeroArma;
    // Start is called before the first frame update
    void Start()
    {
        logicaTomarArma= GameObject.FindGameObjectWithTag("rigby").GetComponent<LogicaTomarArma>();
        playerRigbyController = GameObject.FindGameObjectWithTag("rigby").GetComponent<PlayerRigbyController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "rigby")
        {
            logicaTomarArma.activarArma(numeroArma);
            playerRigbyController.TomoEspada(numeroArma);
            Destroy(gameObject);
        }
    }
}
