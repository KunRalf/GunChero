using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private ParticleSystem _targetAura;
    private PopUpDamage _popUpDamage;
    private EnemyDetector _enemyDetector;

    public int Health => _health;

    private void Start()
    {
        _popUpDamage = GetComponent<PopUpDamage>();
        _enemyDetector = FindObjectOfType<EnemyDetector>();
        EventService.Instance.CallOnEnemyCreate(this);
      }


    private void Update()
    {
        if (_health <= 0)
        {
            DestroyEnemy();
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _popUpDamage.CreatePopUpDamage(damage);
    }

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
        _enemyDetector.RemoveEnemy(this);
    }

    public void TurnOnAura()
    {
        if (!_targetAura.isPlaying)
            _targetAura.Play();
    }

    public void TurnOffAura()
    {
        if (_targetAura.isPlaying)
            _targetAura.Stop();
    }
}
