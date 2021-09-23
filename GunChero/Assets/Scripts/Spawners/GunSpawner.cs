using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyGun;

    private void SpawnGun()
    {
        GameObject gun = Instantiate(_enemyGun) as GameObject;
        gun.transform.position = transform.position;
    }

    private void Start()
    {
        SpawnGun();
    }


}
