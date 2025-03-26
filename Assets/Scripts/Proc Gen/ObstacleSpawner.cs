using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _obstaclePrefabs;
    [SerializeField] float _obstacleSpawnTime = 1f;
    [SerializeField] Transform _obstacleParent;
    [SerializeField] float _spawnWidth = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstaclePrefab = _obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-_spawnWidth, _spawnWidth), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(_obstacleSpawnTime);
            Instantiate(obstaclePrefab, transform.position, Random.rotation, _obstacleParent);
        }
    }
}
