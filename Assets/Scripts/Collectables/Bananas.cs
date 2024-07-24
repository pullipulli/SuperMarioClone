using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bananas : Collectable
{
    protected new void Awake()
    {
        base.Awake();
    }

    public override void Use(Upgradeable upgradeable)
    {
        upgradeable.InvincibleMode(10f);
        upgradeable.ChangeColor(Color.cyan);
    }
}
