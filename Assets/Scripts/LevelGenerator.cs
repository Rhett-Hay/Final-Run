using Unity.Mathematics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject _platformPrefab;
    [SerializeField] int _startingPlatformAmount = 12;
    [SerializeField] Transform _platformParent;
    [SerializeField] float _platformLength = 10f;
    [SerializeField] float _moveSpeed = 8f;

    GameObject[] chunks = new GameObject[12];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnChunks();
    }

    void Update() 
    {
        MoveChunks();
    }

    void SpawnChunks()
    {
        for (int i = 0; i < _startingPlatformAmount; i++)
        {
            float spawnPositionZ = CalculateSpawnPositionZ(i);
            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
            GameObject newChunk = Instantiate(_platformPrefab, chunkSpawnPos, Quaternion.identity, _platformParent);
            chunks[i] = newChunk;
        }
    }

    private float CalculateSpawnPositionZ(int i)
    {
        float spawnPositionZ;

        if (i == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            // Spawn slabs in front of the player
            spawnPositionZ = transform.position.z + (i * _platformLength);
        }

        return spawnPositionZ;
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Length; i++)
        {
            chunks[i].transform.Translate(-transform.forward * (_moveSpeed * Time.deltaTime));
        }
    }
}
