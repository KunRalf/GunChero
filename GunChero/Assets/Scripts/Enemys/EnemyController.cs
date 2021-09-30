using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _health = 100;


    private void Update()
    {
        if (_health <= 0)
        {
            Debug.Log("Enemy is dead");
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public void TurnOffEnemy()
    {
        gameObject.SetActive(false);
    }

    public void TurnOnEnemy()
    {
        gameObject.SetActive(true);
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
