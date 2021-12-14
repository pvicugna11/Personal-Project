using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody objectRb;
    private GameObject player;
    public float speed = 2.0f;

    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector3 lookDirection = player.transform.position - transform.position;

        objectRb.AddForce(lookDirection * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
