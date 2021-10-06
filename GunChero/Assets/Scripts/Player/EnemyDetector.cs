using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private List<EnemyController> _enemies = new List<EnemyController>();
    private Transform _closestEnemy;
    [SerializeField] private EventService _eventService;

    private void OnEnable()
    {
        EventService.Instance.OnEnemyCreate += AddEnemy;
    }

    private void OnDisable()
    {
        EventService.Instance.OnEnemyCreate -= AddEnemy;
    }

    public int GetEnemyCount()
    {
        return _enemies.Count;
    }

    public void AddEnemy(EnemyController enemy)
    {
        _enemies.Add(enemy);
    }

    public void ClearEnemyList()
    {
        _enemies.Clear();
    }

    public void RemoveEnemy(EnemyController enemy)
    {
        _enemies.Remove(enemy);
    }

    public Transform GetClosestEnemy()
    {
        _closestEnemy = ClosestEnemy();
        return _closestEnemy;
    }

    public Transform ClosestEnemy()
    {
        Transform closestEnemy = null;
        float _minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (EnemyController enemy in _enemies)
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
