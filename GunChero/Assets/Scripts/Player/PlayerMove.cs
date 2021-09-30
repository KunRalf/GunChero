using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _gravity = 0.5f;
    [SerializeField] private FloatingJoystick _joystick;
    private PlayerController _playerController;

    private Vector3 _playerDirection;
    private float _rotateSpeed = 0.5f;
    private Rigidbody _playerRgb;

    private EnemyController _enemy;



    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _enemy = FindObjectOfType<EnemyController>();
        _playerRgb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        /*if (_playerController.IsShooting)
        {
            transform.LookAt(_enemy.transform);
        }*/
        

        _playerDirection.y = 0;
        _playerDirection.x = _joystick.Horizontal;
        _playerDirection.z = _joystick.Vertical;

        if (_playerDirection != Vector3.zero)
        {
            Vector3 moveDirection = Vector3.RotateTowards(transform.forward, _playerDirection, _rotateSpeed, 0f);
            transform.rotation = Quaternion.LookRotation(moveDirection);

        }
        _playerRgb.velocity = new Vector3(_playerDirection.normalized.x * _moveSpeed, _playerRgb.velocity.y - _gravity, _playerDirection.normalized.z * _moveSpeed);
    }
}
