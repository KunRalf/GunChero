using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private ParticleSystem _targetAura;
    private EnemyDetector _enemyDetector;

    private void Awake()
    {
        
    }

    private void Start()
    {
        _enemyDetector = FindObjectOfType<EnemyDetector>();
        EventService.Instance.CallOnJellyCreate(this);
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
