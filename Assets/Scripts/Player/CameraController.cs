using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] ParticleSystem _speedupParticleSystem;
    [SerializeField] float _minFOV = 20f;
    [SerializeField] float _maxFOV = 120f;
    [SerializeField] float _zoomDuration = 1f;
    [SerializeField] float _zoomSpeedModifier = 5f;

    CinemachineCamera _cinemachineCamera;

    void Awake() 
    {
        _cinemachineCamera = GetComponent<CinemachineCamera>();    
    }

    public void ChangeCameraFOV(float speedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(speedAmount));

        if (speedAmount > 0)
        {
            _speedupParticleSystem.Play();
        }
    }

    IEnumerator ChangeFOVRoutine(float speedAmount)
    {
        float startFOV = _cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount * _zoomSpeedModifier, _minFOV, _maxFOV);
        float elapsedTime = 0f;

        while (elapsedTime < _zoomDuration)
        {
            float t = elapsedTime / _zoomDuration;
            elapsedTime += Time.deltaTime;

            _cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }

        _cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
}
