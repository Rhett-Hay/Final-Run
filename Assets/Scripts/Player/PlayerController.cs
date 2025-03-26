using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _xClamp = 3f;
    [SerializeField] float _zClamp = 3f;

    Vector2 _movement;
    Rigidbody _rigidBody;

    void Awake() 
    {
        _rigidBody = GetComponent<Rigidbody>();    
    }

    void FixedUpdate() 
    {
        HandleMovement();    
    }

    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    private void HandleMovement()
    {
        Vector3 currentPosition = _rigidBody.position;
        Vector3 moveDirection = new Vector3(_movement.x, 0f, _movement.y);
        Vector3 newPosition = currentPosition + moveDirection * (_moveSpeed * Time.fixedDeltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, -_xClamp, _xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -_zClamp, _zClamp);
        _rigidBody.MovePosition(newPosition);
    }
}
