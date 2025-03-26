using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] float _collisionCooldown = 1f;

    const string _hitString = "Hit";
    float _coolDownTimer = 0f;

    void Update() 
    {
        _coolDownTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (_coolDownTimer < _collisionCooldown) return;
        
        _animator.SetTrigger(_hitString);
        _coolDownTimer = 0f;
    }
}
