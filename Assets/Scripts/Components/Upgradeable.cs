using UnityEngine;

[RequireComponent(typeof(Health), typeof(SpriteRenderer))]
public class Upgradeable : MonoBehaviour
{
    private Health health;
    private SpriteRenderer spriteRenderer;
    public bool canShoot = false;
    private int coins = 0;

    public float Hp { get { return health.hp; } }

    private void Awake()
    {
        health = GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }

    public void HealthUpgrade()
    {
        health.hp = 2;
    }

    public void IncrementCoin()
    {
        coins++;
        Debug.Log("MONETE: " + coins);
    }
}

