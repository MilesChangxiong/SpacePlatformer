using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] public float speed = 1.0f;
    [SerializeField] public float jumpForce = 3.0f;
    [SerializeField] public float maxVerticalSpeedForJump = 5.0f;
    [SerializeField] public float fadeSpeed = 2.0f;
    [SerializeField] public float maxChaseDistance = 10.0f;
    //[SerializeField] private float avoidDistance = 2f; 
    //[SerializeField] private float avoidForce = 5f;

    private Transform target;
    private Rigidbody2D rb;
    private bool isPlayerFacingMe = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckPlayerFacingDirection();
        //if (collision.CompareTag("Player"))

        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        if (!isPlayerFacingMe || distanceToPlayer > maxChaseDistance)
        {
            FollowPlayer();
            TryJump();
        }
        

        else
        {
            rb.velocity = Vector2.zero; 
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
        float targetAlpha = 0;  // Desired alpha value (0 = invisible, 1 = fully visible)
        
        if ((target.localScale.x > 0 && transform.position.x > target.position.x) ||
           (target.localScale.x < 0 && transform.position.x < target.position.x))
        {
            isPlayerFacingMe = true;
            targetAlpha = 1;  
        }
        else
        {
            isPlayerFacingMe = false;
            targetAlpha = 0;  
        }
        
        Color newColor = spriteRenderer.color;
        newColor.a = Mathf.MoveTowards(newColor.a, targetAlpha, fadeSpeed * Time.deltaTime);
        spriteRenderer.color = newColor;
    }

/*    void AvoidOtherEnemies()
    {
        
        EnemyFollow[] enemies = FindObjectsOfType<EnemyFollow>();
    
        foreach (EnemyFollow enemy in enemies)
        {
            
            if (enemy == this) continue;

            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < avoidDistance)
            {
                Vector2 avoidDirection = (transform.position - enemy.transform.position).normalized;
                rb.velocity += avoidDirection * avoidForce * Time.deltaTime;
            }
        }

    }*/

}
