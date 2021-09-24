﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    private PlayerController _playerController;
    private Animator _animator;

    private const string RUNNING_ANIMATION = "_isRun";
    private const string SHOTING_ANIMATION = "_isShoot";
    private const string DEATH_ANIMATION = "_isDeath";


    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }

    private void RunningAnimation()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _animator.SetBool(RUNNING_ANIMATION, true);
        }
        else
        {
            _animator.SetBool(RUNNING_ANIMATION, false);
        }
    }

    private void DeathAnimation()
    {
        if (!_playerController.IsAlive)
        {
            _animator.SetBool(DEATH_ANIMATION, true);
        }
    }

    private void Update()
    {
        DeathAnimation();
        RunningAnimation();
    }
}
