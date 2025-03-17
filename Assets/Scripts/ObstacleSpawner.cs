using System;
using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] float _obstacleSpawnTime = 1f;

    int _obstaclesSpawned = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (_obstaclesSpawned < 5)
        {
            yield return new WaitForSeconds(_obstacleSpawnTime);
            Instantiate(_obstaclePrefab, transform.position, Quaternion.identity);
            _obstaclesSpawned++;
        }
    }
}
