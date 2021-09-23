using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemuGunShooting : MonoBehaviour
{
    [SerializeField] private EnemyGunBullet _bullet;
    [SerializeField] private Transform _shotPoint;
    private EnemyGunAnimator _animator;

    private void Start()
    {
        _animator = GetComponent<EnemyGunAnimator>();
    }

    private void Shoot()
    {
        EnemyGunBullet bullet = Instantiate(_bullet);
        bullet.transform.position = _shotPoint.position;
        bullet.transform.rotation = _shotPoint.rotation;
    }


    private void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            _animator.ShootAnim();
        }
    }
}
