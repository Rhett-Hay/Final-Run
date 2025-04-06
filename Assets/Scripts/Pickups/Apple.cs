using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float _adjustChangeMoveSpeedAmount = 3f;

    LevelGenerator _levelGenerator;

    public void Init(LevelGenerator levelGenerator) 
    {
        this._levelGenerator = levelGenerator;   
    }
    protected override void OnPickup()
    {
        Debug.Log("Power Up!");
        _levelGenerator.ChangePlatformMoveSpeed(_adjustChangeMoveSpeedAmount);
    }
}
