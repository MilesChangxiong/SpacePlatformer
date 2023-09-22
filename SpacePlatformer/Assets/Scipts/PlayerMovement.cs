using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Jump_speed;
    [SerializeField] private float flyForce = 3.5f;
    private Rigidbody2D body;
    private Animator Anim;
    private bool grounded;
    private GameManager gameManager;
    public float maxAirTime = 10.0f; 
    public float currentAirTime = 0.0f;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Awake()
    {
        //reference to rigidbody and animator
        body = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(horizontalInput*speed, body.velocity.y);
        
        
        if(horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);

        if(Input.GetKey(KeyCode.Space)) //&& grounded)
            Float();

        //if (Input.GetKey(KeyCode.LeftShift))
        //    Jump();

        Anim.SetBool("Walk",horizontalInput != 0);
        Anim.SetBool("grounded",grounded);
         
    }

    
    /*private void Jump(){
        body.velocity = new Vector3(body.velocity.x, Jump_speed);
        grounded = false;
    }*/

    private void Float()
    {
        //body.velocity = new Vector3(body.velocity.x, Jump_speed);
        if (currentAirTime < maxAirTime)
        {
            body.AddForce(Vector2.up * flyForce);
            currentAirTime += Time.deltaTime;
        }
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform"){
            grounded = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            
            gameManager.OnPlayerDefeated();
            //Time.timeScale = 0;
        }
        else if (collision.CompareTag("Destination"))
        {
            gameManager.OnPlayerWin();
            //Time.timeScale = 0;
        }
    }

}
