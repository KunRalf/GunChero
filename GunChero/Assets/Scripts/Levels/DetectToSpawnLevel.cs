using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectToSpawnLevel : MonoBehaviour
{
    private LevelPlacer _levelPlacer;

    private void Start()
    {
        _levelPlacer = FindObjectOfType<LevelPlacer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            _levelPlacer.SpawnLevel();
            Destroy(gameObject);
        }
    }
}
