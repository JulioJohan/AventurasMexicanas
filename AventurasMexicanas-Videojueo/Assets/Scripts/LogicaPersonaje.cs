using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 10.0f;
    public float velocidadRotacion = 200.0f;
    private Animator animator;
    public float horizontal = 0.0f;
    public float vertical = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");    
        vertical = Input.GetAxis("Vertical");
        transform.Rotate(0,horizontal * Time.deltaTime * velocidadRotacion,0);
        transform.Translate(0,0,vertical * Time.deltaTime * velocidadMovimiento);
        animator.SetFloat("velocidadHorizontal",horizontal);
        animator.SetFloat("velocidadVertical",vertical);        
    }


}
