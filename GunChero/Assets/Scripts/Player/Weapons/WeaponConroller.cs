using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConroller : MonoBehaviour
{
    [SerializeField] private GameObject[] _weapons;

   // public bool IsMeleeAttack

    private void Start()
    {
        
    }

    public void ChangeWeapon(int index)
    {
        foreach (GameObject weapon in _weapons)
        {
            weapon.SetActive(false);
            _weapons[index].SetActive(true);
        }
    }

    private void Update()
    {
      //  Debug.Log(_isMeleeAttack);
    }
}
