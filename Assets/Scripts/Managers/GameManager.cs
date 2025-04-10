using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] TMP_Text _timeText;
    [SerializeField] GameObject _gameOverText;
    [SerializeField] float _startTime = 5f;

    float _timeLeft;
    bool _gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _timeLeft = _startTime;    
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseTime();
    }

    private void DecreaseTime()
    {
        if (_gameOver) return;

        _timeLeft -= Time.deltaTime;
        _timeText.text = _timeLeft.ToString("F1");

        if (_timeLeft <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        _gameOver = true;
        _playerController.enabled = false;
        _gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }
}
