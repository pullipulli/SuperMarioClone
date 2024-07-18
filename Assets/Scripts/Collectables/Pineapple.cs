using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineapple : Collectable
{
    public override void Use(Upgradeable upgradeable)
    {
        upgradeable.HealthUpgrade();
        upgradeable.canShoot = false;
        upgradeable.ChangeColor(Color.yellow);
    }
}
