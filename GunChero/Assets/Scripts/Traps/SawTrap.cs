using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MonoBehaviour
{
    private PlayerController _player;
    private int _damage = 3;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            _player.TakeDamage(_damage);
        }
    }
}
