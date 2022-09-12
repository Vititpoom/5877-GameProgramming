using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;


public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private characterColor playerColor;
    private float _moveInput;
    
    

   
    private void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_moveInput * speed, rb.velocity.y);  
    }
    private void OnJump(InputValue value)
    {
        if (value.isPressed) 
        { 
            rb.AddForce((jumpForce * transform.up ), ForceMode2D.Impulse);
        }
    }
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
        //rb.velocity = (transform.right * _moveInput * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out Collect collect))
        {
         characterColor playerColor = collect.color;
        
         switch (playerColor)
         {
            case characterColor.Red:
                spriteRenderer.color = Color.red;
                break;

            case characterColor.Blue:
                spriteRenderer.color = Color.blue;
                break;

            case characterColor.Green:
                spriteRenderer.color = Color.green;
                break;
            case characterColor.Yellow:
                spriteRenderer.color = Color.yellow;
                break;
            }
            Destroy(collect.gameObject);  
        }
    }
}
