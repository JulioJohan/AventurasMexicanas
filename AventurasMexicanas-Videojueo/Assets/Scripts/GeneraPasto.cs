using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GeneraPasto : MonoBehaviour
{

    public GameObject grassPrefab; // Asigna tu prefab de pasto aquí en el Inspector de Unity
    public GameObject plane; // Asigna tu plano aquí en el Inspector de Unity
    public GameObject streetPrefab; // Asigna tu prefab de calle aquí en el Inspector de Unity
    public GameObject grassParent; // Asigna tu objeto padre aquí en el Inspector de Unity

    public float spacing = 1; // Espacio entre cada instancia

    void Start()
    {
        MeshRenderer meshRenderer = plane.GetComponent<MeshRenderer>();
        float width = meshRenderer.bounds.size.x;
        float height = meshRenderer.bounds.size.z;
        Vector3 startPos = plane.transform.position - new Vector3(width / 2, 0, height / 2);
        GameObject[] streets = GameObject.FindGameObjectsWithTag(streetPrefab.tag);

        for (float x = 0; x < width; x += spacing)
        {
            for (float z = 0; z < height; z += spacing)
            {
                Vector3 pos = startPos + new Vector3(x, 0, z);
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

                if (!isStreet)
                {
                    GameObject grass = Instantiate(grassPrefab, pos, Quaternion.identity);
                    grass.transform.parent = grassParent.transform; // Asigna el objeto padre al pasto
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
