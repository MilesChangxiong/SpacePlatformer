using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] public float speed = 1.0f;
    [SerializeField] public float jumpForce = 3.0f;
    [SerializeField] public float maxVerticalSpeedForJump = 5.0f; 

    private Transform target;
    private Rigidbody2D rb;
    private bool isPlayerFacingMe = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckPlayerFacingDirection();
        if (!isPlayerFacingMe)
        {
            FollowPlayer();
            TryJump();
        }
        else
        {
            //rb.velocity = Vector2.zero; 
        }
    }

    void FollowPlayer()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();

        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    void TryJump()
    {
       
        if (target.position.y > transform.position.y + 1f &&
           (rb.velocity.y < maxVerticalSpeedForJump && rb.velocity.y >= 0 || rb.velocity.y < 0))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void CheckPlayerFacingDirection()
    {
        
        if ((target.localScale.x > 0 && transform.position.x > target.position.x) ||
           (target.localScale.x < 0 && transform.position.x < target.position.x))
        {
            isPlayerFacingMe = true;
        }
        else
        {
            isPlayerFacingMe = false;
        }
    }
}
