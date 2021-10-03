using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private List<EnemyController> _enemys = new List<EnemyController>();
    private Transform _closestEnemy;

    public int GetEnemyCount()
    {
        return _enemys.Count;
    }

    public void AddEnemy(EnemyController enemy)
    {
        _enemys.Add(enemy);
    }

    public void ClearEnemyList()
    {
        _enemys.Clear();
    }

    public void RemoveEnemy(EnemyController enemy)
    {
        _enemys.Remove(enemy);
    }

    public Transform GetClosestEnemy()
    {
        _closestEnemy = ClosestEnemy(_enemys);
        return _closestEnemy;
    }

    private Transform ClosestEnemy(List<EnemyController> enemies)
    {
        Transform closestEnemy = null;
        float _minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (EnemyController enemy in enemies)
        {
            float dist = Vector3.Distance(enemy.transform.position, currentPos);
            if (dist < _minDist)
            {
                closestEnemy = enemy.transform;
                _minDist = dist;
            }
        }
        return closestEnemy;
    }
}
