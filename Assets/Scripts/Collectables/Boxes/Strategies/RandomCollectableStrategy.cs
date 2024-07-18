using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CollectableStrategy/Random")]
public class RandomCollectableStrategy : CollectableStrategy
{
    [SerializeField] private List<GameObject> possibleCollectables;
    public override GameObject selectCollectable(Upgradeable upgradeable)
    {
        int index = Random.Range(0, possibleCollectables.Count);

        return possibleCollectables[index];
    }
}
