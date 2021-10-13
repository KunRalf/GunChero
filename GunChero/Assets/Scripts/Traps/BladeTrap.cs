using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTrap : MonoBehaviour
{
    private PlayerController _player;
    private int _damage = 5;
    private float _delayBeforeDamage = 0.8f;
    private float _timer;


    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
                _player.TakeDamage(_damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if(player != null)
        {
            _timer += Time.deltaTime;
            if (_timer > _delayBeforeDamage)
            {
                _timer = 0;
                _player.TakeDamage(_damage);
            }
        }
    }
}
