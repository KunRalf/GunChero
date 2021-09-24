using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombAttack : MonoBehaviour
{

    private int _damage;

    private int GetDamage()
    {
        _damage = Random.Range(15,25);
        return _damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(GetDamage());
            Debug.Log($"bomb damage---- {GetDamage()}");
        }
    }

}
