using UnityEngine;

[RequireComponent(typeof(ProjectileDamage))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed = 10;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
