using Unity.Mathematics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject _chunkPrefab;
    [SerializeField] int _startingChunksAmount = 12;
    [SerializeField] Transform _chunkParent;
    [SerializeField] float _chunkLength = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < _startingChunksAmount; i++)
        {
            float spawnPositionZ;

            if (i == 0)
            {
                spawnPositionZ = transform.position.z;
            }
            else
            {
                // Spawn slabs in front of the player
                spawnPositionZ = transform.position.z + (i * _chunkLength);
            }

            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
            Instantiate(_chunkPrefab, chunkSpawnPos, Quaternion.identity, _chunkParent); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
