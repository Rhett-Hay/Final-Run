using System.Collections.Generic;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject _platformPrefab;
    [SerializeField] int _startingPlatformAmount = 12;
    [SerializeField] Transform _platformParent;
    [SerializeField] float _platformLength = 10f;
    [SerializeField] float _moveSpeed = 8f;

    List<GameObject> _platforms = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnStartingChunks();
    }

    void Update() 
    {
        MoveChunks();
    }

    void SpawnStartingChunks()
    {
        for (int i = 0; i < _startingPlatformAmount; i++)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();
        Vector3 platformSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newPlatform = Instantiate(_platformPrefab, platformSpawnPos, Quaternion.identity, _platformParent);
        _platforms.Add(newPlatform);
    }

    private float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;

        if (_platforms.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            // Spawn slabs in front of the player
            spawnPositionZ = _platforms[_platforms.Count - 1].transform.position.z + _platformLength;
        }

        return spawnPositionZ;
    }

    void MoveChunks()
    {
        for (int i = 0; i < _platforms.Count; i++)
        {
            GameObject platform = _platforms[i];
            platform.transform.Translate(-transform.forward * (_moveSpeed * Time.deltaTime));

            if (platform.transform.position.z <= Camera.main.transform.position.z - _platformLength)
            {
                _platforms.Remove(platform);
                Destroy(platform);
                SpawnPlatform();
            }
        }
    }
}
