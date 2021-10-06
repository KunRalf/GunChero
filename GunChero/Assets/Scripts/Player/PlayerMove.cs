using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _gravity = 0.5f;
    [SerializeField] private FloatingJoystick _joystick;
    private PlayerController _playerController;
    private EnemyDetector _enemyDetector;

    private Vector3 _playerDirection;
    private float _rotateSpeed = 0.5f;
    private Rigidbody _playerRgb;

    private Vector3 _relativePosition;
    private Quaternion _targetRotation;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerRgb = GetComponent<Rigidbody>();
        _enemyDetector = GetComponent<EnemyDetector>();
    }

    private Vector3 ClosestEnemyPosition()
    {
        Vector3 enemyPos = new Vector3(_enemyDetector.ClosestEnemy().position.x, _enemyDetector.ClosestEnemy().position.y, _enemyDetector.ClosestEnemy().position.z);
        return enemyPos;
    }

    private Quaternion ToTargetRotation()
    {
        _relativePosition = ClosestEnemyPosition() - transform.position;
        _targetRotation = Quaternion.LookRotation(_relativePosition);
        return _targetRotation;
    }

    private void FixedUpdate()
    {
        if (_enemyDetector.GetEnemyCount() > 0 && _playerDirection == Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, ToTargetRotation(), 0.15f);
            if (_enemyDetector.ClosestEnemy() != null)
                _enemyDetector.ClosestEnemy().GetComponent<EnemyController>().TurnOnAura();
        }

        _playerDirection.y = 0;
        _playerDirection.x = _joystick.Horizontal;
        _playerDirection.z = _joystick.Vertical;

        if (_playerDirection != Vector3.zero)
        {
             Vector3 moveDirection = Vector3.RotateTowards(transform.forward, _playerDirection, _rotateSpeed, 0f);
             transform.rotation = Quaternion.LookRotation(moveDirection);
             if(_enemyDetector.ClosestEnemy() != null)
                _enemyDetector.ClosestEnemy().GetComponent<EnemyController>().TurnOffAura();
        }

        _playerRgb.velocity = new Vector3(_playerDirection.normalized.x * _moveSpeed, _playerRgb.velocity.y - _gravity, _playerDirection.normalized.z * _moveSpeed);
    }
}
