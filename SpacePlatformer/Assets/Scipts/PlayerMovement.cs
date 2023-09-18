using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Jump_speed;
    private Rigidbody2D body;
    
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(horizontalInput*speed, body.velocity.y);
        
        //left right flip direction KeyCode
        if(horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);

        if(Input.GetKey(KeyCode.Space))
            body.velocity = new Vector3(body.velocity.x, Jump_speed);
    }
}
