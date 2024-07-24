using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Damageable : MonoBehaviour
{
    private Health health;

    [SerializeField] private UnityEvent onHit;
    [SerializeField, Tooltip("How many times in a second the object can be damaged")] private float damageRate = 1f;

    private float canTakeDamage = -1;

    public bool Invincible { get; set; }


    private void Awake()
    {
        health = GetComponent<Health>();
    }

    public void DealDamage(float damageAmount)
    {
        if (Time.time > canTakeDamage && !Invincible)
        {
            canTakeDamage = Time.time + damageRate;
            onHit.Invoke();
            health.ChangeHealth(damageAmount);
        }
    }

}
