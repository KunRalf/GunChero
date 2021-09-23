using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _health;
    private bool _isAlive;

    public int Health => _health; 

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }


}
