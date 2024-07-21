using System;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool hasCollectable = true;

    private Animator animator;
    private Vector3 position;

    [SerializeField] private CollectableStrategy collectableStrategy;
    [SerializeField] private float xColliderTolerance = 0.25f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 direction = transform.position - collision.transform.position;

        bool isFromBottom = direction.y >= 0;
        bool isFromLeft = direction.x > xColliderTolerance;
        bool isFromRight = direction.x < xColliderTolerance;

        if (collision.gameObject.TryGetComponent(out Upgradeable upgradeable) && hasCollectable 
            && isFromBottom && (!isFromLeft || !isFromRight))
        {
            GameObject collectable = collectableStrategy.selectCollectable(upgradeable);

            animator.SetBool("Hitted", true);

            Instantiate(collectable, position, transform.rotation);

            hasCollectable = false;
            
        }
    }
}
