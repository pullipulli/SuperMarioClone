using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitObject = collision.gameObject;
        TryDamageObject(hitObject);
    }

    void TryDamageObject(GameObject objectToDamage)
    {
        if (objectToDamage.GetComponent<PlayerController>() || objectToDamage.GetComponent<Collectable>()) return;

        if (objectToDamage.TryGetComponent(out Damageable damageableObject))
        {
            damageableObject.DealDamage(-damageAmount);
        }

        Destroy(gameObject);
    }
}
