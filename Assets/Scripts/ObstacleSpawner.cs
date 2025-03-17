using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] float _obstacleSpawnTime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_obstacleSpawnTime);
            Instantiate(_obstaclePrefab, transform.position, Random.rotation);
        }
    }
}
