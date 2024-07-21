using System.Collections;
using UnityEngine;


public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }

    protected void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
