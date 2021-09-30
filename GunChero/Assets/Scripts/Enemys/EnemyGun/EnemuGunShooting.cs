using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemuGunShooting : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private GameObject _bullet;
    private PlayerController _player;
    private EnemyGunAnimator _animator;
    private float _delayBeforeShoot = 0.5f;
    private float _timer;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _animator = GetComponent<EnemyGunAnimator>();
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
                _animator.ShootAnim();
            }
        }


    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bullet) as GameObject;
        bullet.transform.position = _shotPoint.position;
        bullet.transform.rotation = _shotPoint.rotation;
    }
}
