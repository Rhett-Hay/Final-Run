using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CameraController _cameraController;
    [SerializeField] GameObject[] _platformPrefabs;
    [SerializeField] GameObject _checkpointPlatformPrefab;
    [SerializeField] Transform _platformParent;
    [SerializeField] ScoreManager _scoreManager;

    [Header("Level Settings")]
    [Tooltip("The amount of platforms we start with")]
    [SerializeField] int _startingPlatformAmount = 12;
    [SerializeField] int _checkpointPlatformInterval = 8;
    [Tooltip("Do not change platform length value unless platform prefab size reflects change")]
    [SerializeField] float _platformLength = 10f;
    [SerializeField] float _moveSpeed = 8f;
    [SerializeField] float _minMoveSpeed = 2f;
    [SerializeField] float _maxMoveSpeed = 20f;
    [SerializeField] float _minGravityZ = -22f;
    [SerializeField] float _maxGravityZ = -2f;

    List<GameObject> _platforms = new List<GameObject>();
    int _platformsSpawned = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnStartingPlatforms();
    }

    void Update() 
    {
        MovePlatforms();
    }

    public void ChangePlatformMoveSpeed(float speedAmount)
    {
        float newMoveSpeed = _moveSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, _minMoveSpeed, _maxMoveSpeed);
        
        if (newMoveSpeed != _moveSpeed)
        {
            _moveSpeed = newMoveSpeed;
            float newGravityZ = Physics.gravity.z - speedAmount;
            newGravityZ = Mathf.Clamp(newGravityZ, _minGravityZ, _maxGravityZ);
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);

            _cameraController.ChangeCameraFOV(speedAmount);
        }
    }

    void SpawnStartingPlatforms()
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
        GameObject platformToSpawn = ChoosePlatformToSpawn();
        GameObject newPlatformGO = Instantiate(platformToSpawn, platformSpawnPos, Quaternion.identity, _platformParent);
        _platforms.Add(newPlatformGO);
        Platform newPlatform = newPlatformGO.GetComponent<Platform>();
        newPlatform.Init(this, _scoreManager);

        _platformsSpawned++;
    }

    private GameObject ChoosePlatformToSpawn()
    {
        GameObject platformToSpawn;

        if (_platformsSpawned % _checkpointPlatformInterval == 0 && _platformsSpawned != 0)
        {
            platformToSpawn = _checkpointPlatformPrefab;
        }
        else
        {
            platformToSpawn = _platformPrefabs[Random.Range(0, _platformPrefabs.Length)];
        }

        return platformToSpawn;
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

    void MovePlatforms()
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
