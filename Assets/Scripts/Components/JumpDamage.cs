using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpDamage : MonoBehaviour
{
    [SerializeField] private float damageAmount = 1;
    [SerializeField] UnityEvent onJump;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent == null) return;

        GameObject hitObject = collision.gameObject.transform.parent.gameObject;
        TryDamageObject(hitObject);
    }

    void TryDamageObject(GameObject objectToDamage)
    {
        if (objectToDamage.TryGetComponent(out Damageable damageableObject))
        {
            onJump.Invoke();
            damageableObject.DealDamage(-damageAmount);
        }
    }
}
