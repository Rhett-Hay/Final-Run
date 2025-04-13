using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float _checkpointTimeExtension = 5f;

    GameManager _gameManager;

    const string _playerString = "Player";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerString))
        {
            _gameManager.IncreaseTime(_checkpointTimeExtension);
        }
    }
}
