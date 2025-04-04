using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] int _scoreAmount = 100;

    ScoreManager _scoreManager;

    void Start() 
    {
        _scoreManager = FindFirstObjectByType<ScoreManager>();    
    }

    protected override void OnPickup()
    {
        _scoreManager.IncreaseScore(_scoreAmount);
    }
}
