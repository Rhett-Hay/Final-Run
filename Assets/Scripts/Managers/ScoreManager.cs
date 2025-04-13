using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] TMP_Text _scoreText;

    int _score = 0;

    public void IncreaseScore(int amount)
    {
        if (_gameManager.GameOver) return;
        
        _score += amount;
        _scoreText.text = _score.ToString();
    }
}
