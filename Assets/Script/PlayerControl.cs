using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;


public class PlayerControl : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Transform player;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private PlayerAnimatorControl animatorControl;
    [SerializeField] private Collider2D playerColider;
    [SerializeField] private BoxCollider2D playerBoxCollider;
    [SerializeField] private LayerMask playerLayerMask;
    
    

    [Header("Player Value")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float speed = 10f;
    private float coyoteTime = 0.5f;
    private float coyoteTimeCoubter;

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
        //CheckGround();

        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_moveInput * speed, rb.velocity.y);
        if (CheckGround())
        {
            coyoteTimeCoubter = coyoteTime;
        }
        else
        {
            coyoteTimeCoubter -= Time.deltaTime;
        }
    }
     private void OnJump(InputValue value)
    {
        if (value.isPressed && coyoteTimeCoubter > 0) 
        {
            //TryJumping();
            rb.AddForce((jumpForce * transform.up), ForceMode2D.Impulse);
            coyoteTimeCoubter = 0;
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

    private bool CheckGround()
    {
        var playerBounds = playerColider.bounds;

        var raycastHit2D = Physics2D.BoxCast(
                                            playerBounds.center,
                                            playerBounds.size,
                                            0f,
                                            Vector2.down,
                                            groundCheckDistance,
                                            groundLayers
                                           );
       
        return _isGrounded = raycastHit2D.collider != null;

       
    }

    private void SetAnimatorParameters()
    {
        animatorControl.SetAnimetorParameter(rb.velocity, _isGrounded);
    }
    /*private void TryJumping()
    {
        if (!_isGrounded) return;

        rb.AddForce((jumpForce * transform.up), ForceMode2D.Impulse);
    }*/

    
    


}
