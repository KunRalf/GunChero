using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _health;
    private CapsuleCollider _capsuleCollider;
    private bool _isAlive = true;

    public int Health => _health;
    public bool IsAlive => _isAlive;

    private void Start()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    private void Update()
    {
        if(_health <= 0)
        {
            _isAlive = false;
            TurnOffCollider();
        }
    }

    private void TurnOffCollider()
    {
        _capsuleCollider.enabled = false;
    }
}
