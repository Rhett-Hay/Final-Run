using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] int _scoreAmount = 100;

    ScoreManager _scoreManager;

    public void Init(ScoreManager scoreManager) 
    {
        this._scoreManager = scoreManager;    
    }

    protected override void OnPickup()
    {
        _scoreManager.IncreaseScore(_scoreAmount);
    }
}
