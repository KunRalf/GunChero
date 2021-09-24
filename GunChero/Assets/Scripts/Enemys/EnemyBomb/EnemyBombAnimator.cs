using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombAnimator : MonoBehaviour
{
    private Animator _animator;
    private const string ATTACK_ANIM = "_isAttack";


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AttackAnim()
    {
        _animator.SetTrigger(ATTACK_ANIM);
    }
}
