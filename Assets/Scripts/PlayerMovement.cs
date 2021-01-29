using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spr;
    
    [SerializeField] float moveSpeed = 3;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }


    Vector2 movement = new Vector2();
    void FixedUpdate()
    {
        
        
        movement.x = (Input.GetAxisRaw("Horizontal") * moveSpeed * 10);
        movement.y = (Input.GetAxisRaw("Vertical") * moveSpeed * 10);

        if (movement.x > 0)
        {
            spr.flipX = false;
        } else if (movement.x < 0)
        {
            spr.flipX = true;
        }

        rb.velocity = movement;

        if (rb.velocity != Vector2.zero)
        {
            anim.SetBool("Moving", true);
        } else
        {
            anim.SetBool("Moving", false);
        }
        Camera.main.transform.Translate(Input.GetAxisRaw("Horizontal")/(moveSpeed*2f), 0, 0);



    }
}
