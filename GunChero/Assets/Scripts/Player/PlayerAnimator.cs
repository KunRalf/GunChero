using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    private PlayerController _playerController;
    private EnemyDetector _enemyDetector;
    private Animator _animator;
    private bool _isShoot = false;
    public bool IsShoot => _isShoot;


    private const string RUNNING_ANIMATION = "_isRun";
    private const string SHO0TING_ANIMATION = "_isShoot";
    private const string DEATH_ANIMATION = "_isDeath";


    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _enemyDetector = GetComponent<EnemyDetector>();
    }

    private void RunningAnimation()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _animator.SetBool(RUNNING_ANIMATION, true);
            _playerController.IsShooting = false;
        }
        else
        {
            _animator.SetBool(RUNNING_ANIMATION, false);
            if(_enemyDetector.GetEnemyCount() > 0)
                _playerController.IsShooting = true;
            else
                _playerController.IsShooting = false;
        }
    }

    private void DeathAnimation()
    {
        if (!_playerController.IsAlive)
        {
            _animator.SetBool(DEATH_ANIMATION, true);
        }
    }

    private void ShootingAnimation()
    {
        if (_playerController.IsShooting)
        {
            _animator.SetBool(SHO0TING_ANIMATION, _playerController.IsShooting);
        }
        else
        {
            _animator.SetBool(SHO0TING_ANIMATION, _playerController.IsShooting);
        }
    }

    private void Update()
    {
        DeathAnimation();
        RunningAnimation();
        ShootingAnimation();
    }
}
