using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelPlacer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Level[] _levelPrefabs;
    [SerializeField] private Level _firstLevel;

    private List<Level> _spawnedLevels = new List<Level>();

    private void Start()
    {
        _spawnedLevels.Add(_firstLevel);
    }

    private void Update()
    {
/*        if (_player.position.z > _spawnedLevels[_spawnedLevels.Count - 1].Finish.position.z - 10)
        {
            SpawnLevel();
        }*/
    }


    public void SpawnLevel()
    {
        Level newLevel;
        newLevel = Instantiate(_levelPrefabs[Random.Range(0,_levelPrefabs.Length)]);
        newLevel.transform.position = _spawnedLevels[_spawnedLevels.Count-1].Finish.position - newLevel.Start.position;
        _spawnedLevels.Add(newLevel);
    }
}
