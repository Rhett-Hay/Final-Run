using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] GameObject _fencePrefab;
    [SerializeField] GameObject _applePrefab;
    [SerializeField] GameObject _coinPrefab;

    [SerializeField] float _appleSpawnChance = .3f;
    [SerializeField] float _coinSpawnChance = .5f;
    [SerializeField] float _coinSeperationLength = 2f;

    [SerializeField] float[] _lanes = { -2.5f, 0, 2.5f};
    List<int> _availableLanes = new List<int> {0, 1, 2};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    void SpawnCoins()
    {
        if (Random.value > _coinSpawnChance || _availableLanes.Count <= 0) return;

        int selectedLane = SelectLane();

        int maxCoinsToSpawn = 6;
        int coinsToSpawn = Random.Range(1, maxCoinsToSpawn);

        float topOfPlatformZPos = transform.position.z + (_coinSeperationLength * 2f);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfPlatformZPos - (i * _coinSeperationLength);
            Vector3 spawnPosition = new Vector3(_lanes[selectedLane], transform.position.y, spawnPositionZ);
            Instantiate(_coinPrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    void SpawnApple()
    {
        if (Random.value > _appleSpawnChance || _availableLanes.Count <= 0) return;

        int selectedLane = SelectLane();

        Vector3 spawnPosition = new Vector3(_lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(_applePrefab, spawnPosition, Quaternion.identity, this.transform);
    }

    void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, _lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (_availableLanes.Count <= 0) break;
            
            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(_lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(_fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, _availableLanes.Count);
        int selectedLane = _availableLanes[randomLaneIndex];
        _availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
