using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //Se crea una variable del tipo de player
    public PlayerRigbyController playerController;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        playerController.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerController.puedoSaltar = false;
    }
}
