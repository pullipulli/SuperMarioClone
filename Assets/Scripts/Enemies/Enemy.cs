using System;
using UnityEditor;
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

    private bool IsVisible()
    {
        Vector3 posInCamera = Camera.main.WorldToViewportPoint(transform.position);

        return posInCamera.x >= 0 && posInCamera.x <= 1 && posInCamera.y >= 0 && posInCamera.y <= 1 && posInCamera.z >= 0;
    }


    protected void Awake()
    {
        animator = GetComponent<Animator>();
        movementComponent = GetComponent<Movement>();
    }

    protected void Update()
    {
        if (IsVisible())
            movementComponent.Move(new Vector2(xDirection, 0));
    }

    protected void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayCastOrigin.transform.position, new Vector2(xDirection, 0), maxRayCastDistance);

        if (hit.collider != null)
        {

            if (hit.collider.gameObject.TryGetComponent(out Enemy other))
            {
                FlipEnemy(other);
                FlipEnemy(this);
            }
            else if (!hit.collider.gameObject.TryGetComponent(out PlayerController _))
            {
                FlipEnemy(this);
            }
                
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 direction = rayCastOrigin.transform.TransformDirection(Vector2.right) * maxRayCastDistance;
        Gizmos.DrawRay(rayCastOrigin.transform.position, direction);
    }

    private void FlipEnemy(Enemy enemy)
    {
        enemy.xDirection = -xDirection;
    }

    public void Death()
    {
        animator.SetBool("Dead", true);
        Destroy(gameObject, 0.5f);
    }
}
