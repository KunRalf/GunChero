using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public void TurnOffEnemy()
    {
        gameObject.SetActive(false);
    }

    public void TurnOnEnemy()
    {
        gameObject.SetActive(true);
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
