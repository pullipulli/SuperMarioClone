using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CollectableStrategy/Upgrade")]
public class UpgradeCollectableStrategy : CollectableStrategy
{
    [SerializeField] private GameObject basicCollectable;
    [SerializeField] private GameObject upgradedCollectable;

    public override GameObject selectCollectable(Upgradeable upgradeable)
    {
        return upgradeable.Hp == 2 ? upgradedCollectable : basicCollectable;
    }
}
