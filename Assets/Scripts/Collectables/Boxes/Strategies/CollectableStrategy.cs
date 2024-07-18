using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableStrategy : ScriptableObject
{
    public abstract GameObject selectCollectable(Upgradeable upgradeable);
}
