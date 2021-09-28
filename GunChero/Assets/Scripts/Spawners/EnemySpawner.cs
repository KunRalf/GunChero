using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemy;

    private void SpawnGun()
    {
        GameObject gun = Instantiate(_enemy[Random.RandomRange(0,_enemy.Length)]) as GameObject;
        gun.transform.position = transform.position;
    }

    private void Start()
    {
        SpawnGun();
    }


}
