using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUp : Collectable
{
    private GameManager gameManager;
    protected new void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public override void Use(Upgradeable upgradeable)
    {
        gameManager.IncrementLives();
    }
}
