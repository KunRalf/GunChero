using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private int _damage = 10;
    private PlayerController _playerController;


    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            _playerController.TakeDamage(_damage);
        }
        Destroy(gameObject);

    }
}
