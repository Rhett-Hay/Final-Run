using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] GameObject _fencePrefab;
    [SerializeField] float[] _lanes = { -2.5f, 0, 2.5f};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnFence();
    }

    private void SpawnFence()
    {
        List<int> availableLanes = new List<int> {0, 1, 2};
        int fencesToSpawn = Random.Range(0, _lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;
            
            int randomLaneIndex = Random.Range(0, availableLanes.Count);
            int selectedLane = availableLanes[randomLaneIndex];
            availableLanes.RemoveAt(randomLaneIndex);

            Vector3 spawnPosition = new Vector3(_lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(_fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }
}
