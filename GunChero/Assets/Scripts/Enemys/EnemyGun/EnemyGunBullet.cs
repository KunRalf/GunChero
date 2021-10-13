using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class EnemyGunBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private int _damage = 10;
    private PlayerController _playerController;
    private PoolObject _poolObject;

    private void Start()
    {
        _poolObject = GetComponent<PoolObject>();
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        PlayerController player = collider.GetComponent<PlayerController>();
        if (player != null)
        {
            _playerController.TakeDamage(_damage);
            _poolObject.ReturnToPool();
        }

        ObstacleForBullet obstacle = collider.GetComponent<ObstacleForBullet>();
        if (obstacle != null)
        {
            _poolObject.ReturnToPool();
        }
    }
}
