using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunAnimator : MonoBehaviour
{
    private Animator _animator;

    private const string ATTACK_ANIM = "_isAttack";


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ShootAnim()
    {
        _animator.SetTrigger(ATTACK_ANIM);
    }

}
