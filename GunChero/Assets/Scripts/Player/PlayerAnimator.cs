using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    private Animator _animator;

    private const string RUNNIG_FLAG = "_isRun";
    private const string ATTACKING_TRIGGER = "Attack";


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void RunningAnimation()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _animator.SetBool(RUNNIG_FLAG, true);
        }
        else
        {
            _animator.SetBool(RUNNIG_FLAG, false);
        }

    }

    private void Update()
    {
        RunningAnimation();
    }
}
