using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private ScoreManager scoreManager;

    private void Start()
    {
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        inGameCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        scoreManager.DisplayFinalScore();
        Time.timeScale = 0f;
    }

}
