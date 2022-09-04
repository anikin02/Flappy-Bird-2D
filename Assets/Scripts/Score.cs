using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private Text scoreText;

    private void OnEnable()
    {
        bird.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        bird.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        scoreText.text = score.ToString();
    }
}
