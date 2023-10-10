using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    // Update is called once per frame
    void Update()       
    {
        int random = Random.Range(1, 3);
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && random.Equals(1))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
