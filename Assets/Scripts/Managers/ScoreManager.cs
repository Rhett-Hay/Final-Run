using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;

    int _score = 0;

    public void IncreaseScore(int amount)
    {
        _score += amount;
        _scoreText.text = _score.ToString();
    }
}
