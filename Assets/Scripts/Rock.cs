using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] float _shakeModifier = 10f;

    CinemachineImpulseSource _cinemachineImpulseSource;

    void Awake() 
    {
        _cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * _shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);

        _cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }
}
