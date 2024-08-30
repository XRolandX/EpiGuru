using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameManager.EndGame();
        }
        else if (other.CompareTag("Coin"))
        {
            scoreManager.AddScore(10);
            Destroy(other.gameObject);
        }
    }
}
