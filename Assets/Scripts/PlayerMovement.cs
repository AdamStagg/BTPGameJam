using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 3;
    [SerializeField] float playerMaxSpeed = 5;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (rb.velocity.magnitude <= playerMaxSpeed)
        {
                if (Input.GetAxisRaw("Horizontal") > 0.1 || Input.GetAxisRaw("Horizontal") < -0.1)
            {
                rb.AddForce(Vector2.right * Input.GetAxisRaw("Horizontal") * moveSpeed);
            }
            if (Input.GetAxisRaw("Vertical") > 0.1 || Input.GetAxisRaw("Vertical") < -0.1)
            {
                rb.AddForce(Vector2.up * Input.GetAxisRaw("Vertical") * moveSpeed);
            }
        }
        
    }
}
