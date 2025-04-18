using System;
using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem _collisionParticleSystem;
    [SerializeField] AudioSource _boulderSmashAudioSource;
    [SerializeField] float _shakeModifier = 10f;
    [SerializeField] float _collisionCooldown = 1f;

    CinemachineImpulseSource _cinemachineImpulseSource;

    float _collisionTimer = 0f;

    void Awake() 
    {
        _cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update() 
    {
        _collisionTimer += Time.deltaTime;   
    }

    void OnCollisionEnter(Collision other)
    {
        if (_collisionTimer < _collisionCooldown) return;

        FireImpulse();
        CollisionFX(other);
    }

    private void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.GetContact(0);
        _collisionParticleSystem.transform.position = contactPoint.point;
        _collisionParticleSystem.Play();
        _boulderSmashAudioSource.Play();
    }

    private void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * _shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);

        _cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }
}
