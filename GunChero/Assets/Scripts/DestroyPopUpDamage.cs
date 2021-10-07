using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class DestroyPopUpDamage : MonoBehaviour
{
    private PoolObject _poolObject;

    private void Start()
    {
        _poolObject = GetComponent<PoolObject>();
    }

    public void DestroyParent()
    {
        _poolObject.ReturnToPool();
    }
}
