using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private PopUpDamage _popUpDamage;
    [SerializeField] private CapsuleCollider _deathCollider;
    private CapsuleCollider _capsuleCollider;
    private bool _isAlive = true;
    private bool _isShoot;

    public int Health => _health;
    public bool IsAlive => _isAlive;
    public bool IsShooting { get { return _isShoot; } set { _isShoot = value; } }

    private void Start()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _popUpDamage.CreatePopUpDamage(damage);
    }

    private void Update()
    {
        if(_health <= 0)
        {
            _isAlive = false;
            TurnOffCollider();
            TurnOnDeathCollider();
        }
    }

    private void TurnOffCollider()
    {
        _capsuleCollider.enabled = false;
    }

    private void TurnOnDeathCollider()
    {
        _deathCollider.enabled = true;   
    }
}
