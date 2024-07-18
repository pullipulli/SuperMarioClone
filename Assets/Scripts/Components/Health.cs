using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float hp;

    [SerializeField] private UnityEvent onHealthZero;
    

    public void ChangeHealth(float amountToChange)
    {
        hp += amountToChange;

        if (hp <= 0)
            onHealthZero.Invoke();
    }
}
