using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool hasCollectable = true;

    private Animator animator;
    private Vector3 position;

    [SerializeField] private CollectableStrategy collectableStrategy;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO hit solo da sotto
        if (collision.gameObject.TryGetComponent(out Upgradeable upgradeable) && hasCollectable)
        {
            GameObject collectable = collectableStrategy.selectCollectable(upgradeable);

            animator.SetBool("Hitted", true);

            Instantiate(collectable, position, transform.rotation);

            hasCollectable = false;
            
        }
    }
}
