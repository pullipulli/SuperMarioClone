using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damageable))]
public class Snail : Enemy
{
    public void ShellMode()
    {
        base.animator.SetBool("ShellMode", true);
        base.movementComponent.doubleSpeed();
    }
}
