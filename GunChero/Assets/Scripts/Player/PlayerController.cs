using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _health;
    private bool _isAlive = true;

    public int Health => _health;
    public bool IsAlive => _isAlive;

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    private void Update()
    {
        if(_health <= 0)
        {
            _isAlive = false;
        }
    }
}
