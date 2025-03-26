using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float _rotationSpeed = 100f;
    
    const string _playerString = "Player";

    void Update() 
    {
        transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerString))
        {
            OnPickup();
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickup();
}
