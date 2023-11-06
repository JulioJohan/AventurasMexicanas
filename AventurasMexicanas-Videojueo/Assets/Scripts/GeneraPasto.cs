using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GeneraPasto : MonoBehaviour
{

    public GameObject grassPrefab; // Asigna tu prefab de pasto aquí en el Inspector de Unity
    public GameObject plane; // Asigna tu plano aquí en el Inspector de Unity
    public GameObject streetPrefab; // Asigna tu prefab de calle aquí en el Inspector de Unity
    public float spacing = 1; // Espacio entre cada instancia

    void Start()
    {
        // Obtiene el MeshRenderer del plano
        MeshRenderer meshRenderer = plane.GetComponent<MeshRenderer>();

        // Calcula el ancho y la altura del plano usando las dimensiones del MeshRenderer
        float width = meshRenderer.bounds.size.x;
        float height = meshRenderer.bounds.size.z;

        // Calcula la posición inicial (esquina inferior izquierda del plano)
        Vector3 startPos = plane.transform.position - new Vector3(width / 2, 0, height / 2);

        // Busca todos los objetos de calle en la escena
        GameObject[] streets = GameObject.FindGameObjectsWithTag(streetPrefab.tag);

        for (float x = 0; x < width; x += spacing)
        {
            for (float z = 0; z < height; z += spacing)
            {
                // Calcula la posición del nuevo objeto
                Vector3 pos = startPos + new Vector3(x, 0, z);

                // Verifica si hay una calle en la posición actual
                Collider[] hitColliders = Physics.OverlapSphere(pos, spacing / 2);
                bool isStreet = false;
                foreach (var hitCollider in hitColliders)
                {
                    if (Array.Exists(streets, street => street == hitCollider.gameObject))
                    {
                        isStreet = true;
                        break;
                    }
                }

                // Si no hay una calle, instancia el pasto
                if (!isStreet)
                {
                    Instantiate(grassPrefab, pos, Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
