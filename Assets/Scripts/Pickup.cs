using UnityEngine;

public class Pickup : MonoBehaviour
{
    const string _playerString = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerString))
        {
            Debug.Log(other.gameObject.name);
        }
    }
}
