using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pool))]
public class EnemuGunShooting : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;
    private PlayerController _player;
    private float _delayBeforeShoot = 0.5f;
    private float _timer;
    private Pool _pool;

    private void Start()
    {
        _pool = GetComponent<Pool>();
        _player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_player.IsAlive)
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
        _pool.GetFreeElement(_shotPoint.position, _shotPoint.rotation);
    }
}
