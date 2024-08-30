using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TMP_Text inGameScoreText;
    [SerializeField] private TMP_Text gameOverScoreText;

    public void AddScore(int amount)
    {
        score += amount;
        UpdateInGameScore();
    }
    private void UpdateInGameScore()
    {
        if (inGameScoreText != null)
        {
            inGameScoreText.text = "Score: " + score;
        }
    }

    public void DisplayFinalScore()
    {
        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "Final Score: " + score;
        }
    }
}
