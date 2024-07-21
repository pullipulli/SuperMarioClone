using System;
using UnityEngine;

[RequireComponent(typeof(CollisionDamage), typeof(Animator), typeof(Movement))]
public abstract class Enemy : MonoBehaviour
{
    protected Animator animator;
    protected Movement movementComponent;

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform rayCastOrigin;
    [SerializeField, Range(0, 1)] private float maxRayCastDistance = 0.5f;

    private float xDirection = 1f;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
        movementComponent = GetComponent<Movement>();
    }

    protected void Update()
    {
        movementComponent.Move(new Vector2(xDirection, 0));
    }

    protected void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayCastOrigin.transform.position, new Vector2(xDirection, 0), maxRayCastDistance);

        if (hit.collider != null && !hit.collider.gameObject.TryGetComponent(out PlayerController _))
            xDirection = -xDirection;
    }

    public void Death()
    {
        animator.SetBool("Dead", true);
        Destroy(gameObject, 0.5f);
    }
}
