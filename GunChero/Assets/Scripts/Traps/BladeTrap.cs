using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTrap : MonoBehaviour
{
    private PlayerController _player;
    private float _delayDamage = 1f;
    private int _damage = 5;
    private Coroutine _damagePerTime;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if(player != null)
        {
            _damagePerTime = StartCoroutine(DamagePerTime(_player.Health, _delayDamage));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator DamagePerTime(int n, float time)
    {
         for (int i = 0; i < n; i++)
         {
            if (_player.IsAlive) 
            { 
             _player.TakeDamage(_damage);
            }
            yield return new WaitForSeconds(time);
         }
    }
}
