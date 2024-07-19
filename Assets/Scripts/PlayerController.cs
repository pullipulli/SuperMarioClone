using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    private float xMovement = 0;

    private Animator animator;
    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Upgradeable upgradeable;
    private Movement movementComponent;

    [SerializeField] private float jumpForce = 10;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform ceilingCheck;
    [SerializeField] private float ceilingRadius = .01f;
    [SerializeField] private float groundedRadius = .01f;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        upgradeable = GetComponent<Upgradeable>();
        movementComponent = GetComponent<Movement>();
    }

    void Update()
    {
        Move();
    }

    void OnDrawGizmosSelected()
    {
        Handles.DrawWireDisc(groundCheck.position, new Vector3(0, 0, 1), groundedRadius);
        Handles.DrawWireDisc(ceilingCheck.position, new Vector3(0, 0, 1), ceilingRadius);
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
        GetComponent<BoxCollider2D>().enabled = false;
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
