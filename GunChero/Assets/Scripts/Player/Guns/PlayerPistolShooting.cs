using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPistolShooting : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private PlayerController _player;
    private PlayerAnimator _animator;
    private float _delayBeforeShoot = 0.5f;
    private float _timer;

    private void Start()
    {
        _animator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_player.IsShooting) { 
        if (_timer > _delayBeforeShoot)
        {
            _timer = 0f;
            Shoot();
        }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bullet,_shotPoint.position, _player.transform.rotation) as GameObject;
    }
}
