using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float _adjustChangeMoveSpeedAmount = 3f;

    LevelGenerator _levelGenerator;

    void Start() 
    {
        _levelGenerator = FindFirstObjectByType<LevelGenerator>();   
    }
    protected override void OnPickup()
    {
        Debug.Log("Power Up!");
        _levelGenerator.ChangePlatformMoveSpeed(_adjustChangeMoveSpeedAmount);
    }
}
