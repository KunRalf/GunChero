using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemuGunShooting : MonoBehaviour
{
    [SerializeField] private EnemyGunBullet _bullet;
    [SerializeField] private Transform _shotPoint;
    private float _shootDelay = 0.7f;
    private PlayerController _player;
    private EnemyGunAnimator _animator;
    private Coroutine _shootingCoroutine;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _animator = GetComponent<EnemyGunAnimator>();
        _shootingCoroutine = StartCoroutine(DelayShooting(_shootDelay));
    }

    private void Shooting()
    {
        EnemyGunBullet bullet = Instantiate(_bullet);
        bullet.transform.position = _shotPoint.position;
        bullet.transform.rotation = _shotPoint.rotation;
    }


    private void Update()
    {
        if (!_player.IsAlive)
        {
            StopCoroutine(_shootingCoroutine);
        }
    }

    private IEnumerator DelayShooting(float time)
    {
        int n = 1;
        for (int i = 0; i < n; i++)
        {
            n++;
            Shooting();
            _animator.ShootAnim();
            yield return new WaitForSeconds(time);
        }
            
        
        
    }
}
