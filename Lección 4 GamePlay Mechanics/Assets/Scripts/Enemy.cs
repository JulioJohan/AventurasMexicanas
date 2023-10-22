using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private float rangeDeleteEmeny = 10;
    private Rigidbody rigidbodyEnemy;
    private GameObject player;
    void Start()
    {
        rigidbodyEnemy = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rigidbodyEnemy.AddForce(lookDirection * speed);
        
        if(transform.position.y <- rangeDeleteEmeny)
        {
            Destroy(gameObject);
        }
    }
}
