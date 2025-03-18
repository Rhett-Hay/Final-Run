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
        int randomLaneIndex = Random.Range(0, _lanes.Length);
        Vector3 spawnPosition = new Vector3(_lanes[randomLaneIndex], transform.position.y, transform.position.z);
        Instantiate(_fencePrefab, spawnPosition, Quaternion.identity, this.transform);
    }
}
