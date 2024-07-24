using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(SpriteRenderer))]
public class Upgradeable : MonoBehaviour
{
    private Health health;
    private SpriteRenderer spriteRenderer;
    private Damageable damageable;
    private Color oldColor;
    public bool canShoot = false;
    private int coins = 0;

    public float Hp { get { return health.hp; } }

    private void Awake()
    {
        health = GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        damageable = GetComponent<Damageable>();
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

    public void InvincibleMode(float invincibleTime)
    {
        damageable.Invincible = true;
        oldColor = spriteRenderer.color;

        Invoke("DamageableAgain", invincibleTime);
    }

    private void DamageableAgain()
    {
        damageable.Invincible = false;

        ChangeColor(oldColor);
    }
}

