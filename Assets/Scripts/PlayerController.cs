using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 100.0f;
    private Rigidbody playerRb;
    private bool isGrounded = true; // 接地
    private bool allowJump = true;  // ジャンプ許可

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGrounded)
            MovePlayer(); // 動く
        
        if (allowJump && Input.GetKeyDown(KeyCode.Space))
            JumpPlayer(); // ジャンプ
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    private void JumpPlayer()
    {
        // 二段ジャンプ
        if (!isGrounded)
        {
            allowJump = false;
        }

        playerRb.AddForce(Vector3.up * speed, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                isGrounded = true;
                allowJump = true;

                break;
            
            case "Enemy":
                Debug.Log("Collides with Enemy");

                break;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Powerup"))
        {
            Destroy(collision.gameObject);
        }
    }
}
