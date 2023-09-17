using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayControl : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // Player's movement speed
    public float jumpForce = 5.0f;  // Force applied when jumping
    public Transform groundCheck;   // A point to check if the player is on the ground
    //public Vector2 groundCheckPosition = new Vector2(transform.position.x, transform.position.y - 1f);
    public float checkRadius = 0.5f; // Radius of the circle used to check if the player is on the ground
    public LayerMask Ground;  // Layer that represents the ground

    private bool isGrounded;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Horizontal movement
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Ground);

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
