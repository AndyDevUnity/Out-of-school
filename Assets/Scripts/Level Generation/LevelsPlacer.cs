using System.Collections.Generic;
using UnityEngine;

public class LevelsPlacer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Levels[] _levelsPrefabs;
    [SerializeField] private Levels _firstLevel;
    private List<Levels> _spawnedLevels = new List<Levels>();

    private void Start()
    {
        _spawnedLevels.Add(_firstLevel);
    }

    private void Update()
    {
        if (_player.position.x > _spawnedLevels[_spawnedLevels.Count - 1]._finish.position.x - 100)
            SpawnLevel();
    }

    private void SpawnLevel()
    {
        Levels newLevel = Instantiate(_levelsPrefabs[Random.Range(0, _levelsPrefabs.Length)]);
        newLevel.transform.position = _spawnedLevels[_spawnedLevels.Count - 1]._finish.position + newLevel._begin.localPosition;
        _spawnedLevels.Add(newLevel);
        DestroyLevel();
    }

    private void DestroyLevel()
    {
        if (_spawnedLevels.Count == 5)
        {
            Destroy(_spawnedLevels[0].gameObject);
            _spawnedLevels.RemoveAt(0);

        }
    }

}
