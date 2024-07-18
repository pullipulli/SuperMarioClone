using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Collectable : MonoBehaviour
{
    private Animator animator;

    abstract public void Use(Upgradeable upgradeable);

    protected void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player;

        if (collision.gameObject.TryGetComponent(out player))
        {
            player.UsePowerUp(this);
            animator.SetBool("Collected", true);
            Destroy(gameObject, 0.5f);
        }
    }
}
