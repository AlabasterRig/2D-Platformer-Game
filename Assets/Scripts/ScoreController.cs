using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI ScoreText;
    private int Score = 0;

    private void Awake()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUI();
    }

    public void IncreaseScore(int IncrementScore)
    {
        Score += IncrementScore;
        RefreshUI();
    }

    private void RefreshUI()
    {
        ScoreText.text = "Score: " + Score;
    }
}
