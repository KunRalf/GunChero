using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Pool))]
public class PopUpDamage : MonoBehaviour
{
    [SerializeField] private Transform _popUp;
    private Pool _pool;

    private void Start()
    {
        _pool = GetComponent<Pool>();
    }

    public void CreatePopUpDamage(int damage)
    {
        Vector3 popUpPos = _popUp.position;
        PoolObject popUpDamage = _pool.GetFreeElement(popUpPos);
        popUpDamage.GetComponent<TextMeshPro>().SetText($"{damage}");
    }

}
