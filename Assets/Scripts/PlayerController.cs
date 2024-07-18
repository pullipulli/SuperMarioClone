using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Damageable))]
[RequireComponent(typeof(Upgradeable))]
[RequireComponent(typeof(Movement))]
[RequireComponent (typeof(JumpDamage))]
public class PlayerController : MonoBehaviour
{
    private bool isGrounded = true;
    private const float ceilingRadius = .01f;
    private const float groundedRadius = .01f;
    private float xMovement = 0;
    
    private Transform groundCheck;
    private Transform ceilingCheck;
    private Animator animator;
    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Health health;
    private Upgradeable upgradeable;
    private Movement movementComponent;

    [SerializeField] private float jumpForce = 10;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootingPoint;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheck");
        ceilingCheck = transform.Find("CeilingCheck");
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        upgradeable = GetComponent<Upgradeable>();
        movementComponent = GetComponent<Movement>();
    }

    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                isGrounded = true;
        }

        animator.SetBool("Ground", isGrounded);
        animator.SetFloat("Jump", rb.velocity.y);
    }

    void OnMove(InputValue inputValue)
    {
        xMovement = inputValue.Get<float>();
    }

    void OnJump(InputValue inputValue)
    {
        if (isGrounded)
        {
            Jump();
        }  
    }

    void OnAttack(InputValue inputValue)
    {
        if (upgradeable.canShoot)
        {
            GameObject instance = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
        }
    }

    private void Move()
    {
        movementComponent.Move(new Vector2(xMovement, 0));
        if (isGrounded)
            animator.SetBool("Run", System.Math.Abs(xMovement) > 0);
    }

    public void UsePowerUp(Collectable powerUp)
    {
        powerUp.Use(upgradeable);
    }

    public void Death()
    {
        animator.SetBool("Dead", true);
        Destroy(gameObject, 0.5f);
        rb.isKinematic = true;
        // game over screen (?)
        // lifeNumber --  (?)
    }

    public void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isGrounded = false;
    }

    public void WhenHit()
    {
        spriteRenderer.color = Color.white;
    }
}
