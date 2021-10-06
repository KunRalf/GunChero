using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class PistolBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private int _damage = 10;
    private Rigidbody _rgb;
    private EnemyController _enemy;
    private PoolObject _poolObject;

    private void Awake()
    {
        _rgb = GetComponent<Rigidbody>();
        _poolObject = GetComponent<PoolObject>();
    }

    private void Start()
    {
         _enemy = FindObjectOfType<EnemyController>();
    }

    private void FixedUpdate()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
        }
        _poolObject.ReturnToPool();

    }
}
