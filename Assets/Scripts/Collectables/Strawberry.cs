using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : Collectable
{
    public override void Use(Upgradeable upgradeable)
    {
        upgradeable.HealthUpgrade();
        upgradeable.canShoot = true;
        upgradeable.ChangeColor(Color.red);
    }
}
