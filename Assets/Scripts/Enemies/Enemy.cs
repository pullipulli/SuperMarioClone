using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionDamage), typeof(Animator), typeof(Movement))]
public abstract class Enemy : MonoBehaviour
{
    protected Animator animator;
    protected Movement movementComponent;

    [SerializeField] protected float xMovement = 2f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsObstacle;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
        movementComponent = GetComponent<Movement>();
    }

    protected void Update()
    {
        movementComponent.Move(new Vector2(xMovement, 0));
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.IsTouchingLayers(whatIsObstacle))
            xMovement = -xMovement;
    }

    public void Death()
    {
        animator.SetBool("Dead", true);
        Destroy(gameObject, 0.5f);
    }
}
