using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] float _collisionCooldown = 1f;
    [SerializeField] float _adjustChangeMoveSpeedAmount = -2f;
    
    const string _hitString = "Hit";
    float _coolDownTimer = 0f;

    LevelGenerator _levelGenerator;

    void Start() 
    {
        _levelGenerator = FindFirstObjectByType<LevelGenerator>();    
    }

    void Update() 
    {
        _coolDownTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (_coolDownTimer < _collisionCooldown) return;
        
        _levelGenerator.ChangePlatformMoveSpeed(_adjustChangeMoveSpeedAmount);
        _animator.SetTrigger(_hitString);
        _coolDownTimer = 0f;
    }
}
