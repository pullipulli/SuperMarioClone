using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CollectableStrategy/Single")]
public class SingleCollectableStrategy : CollectableStrategy
{
    [SerializeField] private GameObject collectable;
    public override GameObject selectCollectable(Upgradeable upgradeable)
    {
        return collectable;
    }
}
