using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pool))]
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _delayBeforeShoot = 0.5f;
    [SerializeField] private EnemyDetector _enemyDetector;
    private PlayerController _player;
    private PlayerAnimator _animator;
    private Pool _pool;
    private float _timer;



    private void Start()
    {
        _pool = GetComponent<Pool>();
        _player = FindObjectOfType<PlayerController>();
        _animator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_player.IsShooting && _player.IsAlive && _enemyDetector.GetEnemyCount() > 0) 
        { 
            if (_timer > _delayBeforeShoot)
            {
                _timer = 0f;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        _pool.GetFreeElement(_shotPoint.position, _player.transform.rotation);
    }
}
