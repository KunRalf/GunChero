using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    private EnemyDetector _enemyDetector;

    private void Start()
    {
        _enemyDetector = FindObjectOfType<EnemyDetector>();
        _enemyDetector.AddEnemy(this);
    }


    private void Update()
    {
        if (_health <= 0)
        {
            Debug.Log("Enemy is dead");
            _enemyDetector.RemoveEnemy(this);
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
        _enemyDetector.RemoveEnemy(this);
    }
}
