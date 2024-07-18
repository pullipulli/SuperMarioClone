using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Collectable
{
    protected new void Awake()
    {
        base.Awake();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.yellow;
        spriteRenderer.material.color = Color.yellow;
    }

    public override void Use(Upgradeable upgradeable)
    {
        upgradeable.IncrementCoin();
    }
}
