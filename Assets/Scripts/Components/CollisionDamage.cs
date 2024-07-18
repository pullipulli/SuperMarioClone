using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public float damageAmount = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitObject = collision.gameObject;
        TryDamageObject(hitObject);
    }

    void TryDamageObject(GameObject objectToDamage)
    {
        if (objectToDamage.TryGetComponent(out Damageable damageableObject))
        {
            damageableObject.DealDamage(-damageAmount);
        }
    }
}
