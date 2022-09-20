using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;


public class PlayerControl : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerAnimatorControl animatorControl;
    [SerializeField] private Collider2D playerColider;

    [Header("Player Value")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float speed = 10f;

    [Header("Grounded Check")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float groundCheckDistance = 0.01f;

    

    // Input Value
    private float _moveInput;

    // Bollean Flags
    private bool _isGrounded;

    private void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
       SetAnimatorParameters();    
       checkGround();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_moveInput * speed, rb.velocity.y);  
    }
     private void OnJump(InputValue value)
    {
        if (value.isPressed) 
        {
            TryJumping();
        }
    }
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
        FlipPlayer();
    }

    private void FlipPlayer()
    {
        if (_moveInput < 0)
        {
            player.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (_moveInput > 0)
        {
            player.localScale = Vector3.one;
        }
    }

    private void checkGround()
    {
        var playerBounds = playerColider.bounds;

        var raycastHit = Physics2D.BoxCast(
                                            playerBounds.center,
                                            playerBounds.size,
                                            0f,
                                            Vector2.down,
                                            groundCheckDistance,
                                            groundLayers
                                           );
        _isGrounded = raycastHit.collider != null;

       
    }

    private void SetAnimatorParameters()
    {
        animatorControl.SetAnimetorParameter(rb.velocity, _isGrounded);
    }
    private void TryJumping()
    {
        if (!_isGrounded) return;

        rb.AddForce((jumpForce * transform.up), ForceMode2D.Impulse);
    }


}
