using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MenuOpciones : MonoBehaviour
    
{
    [SerializeField] private AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void camabiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }
}
