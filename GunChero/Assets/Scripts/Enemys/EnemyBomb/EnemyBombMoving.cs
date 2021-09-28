using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBombMoving : MonoBehaviour
{
    private NavMeshAgent _agent;
    private PlayerController _player;
    private Rigidbody _rgb;
    private EnemyBombAnimator _enemyBombAnimator;
    private bool _isJump = false;

    private IEnumerator Start()
    {
        _enemyBombAnimator = GetComponent<EnemyBombAnimator>();
        _rgb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<PlayerController>();
        yield return new WaitForSeconds(0.1f);
        _agent.enabled = true;
        _agent.SetDestination(_player.transform.position);
        
    }

    private void Update()
    {
        if (_agent.enabled) 
        {
            _agent.SetDestination(_player.transform.position);
            transform.LookAt(_player.transform);
            if (_agent.remainingDistance < 2f)
            {
                _agent.enabled = false;
                Jump();
            }
        }
    }

    private void Jump()
    {
        _isJump = true;
        _rgb.AddForce(0, 300f, 0);
        _rgb.AddForce(transform.forward * 70f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ground ground = collision.gameObject.GetComponent<Ground>();
        if (ground != null && _isJump)
        {
            _enemyBombAnimator.AttackAnim();
        }
    }
}
