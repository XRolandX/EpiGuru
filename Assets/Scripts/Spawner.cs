using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float xRange = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval);
        InvokeRepeating(nameof(SpawnCoin), 0.5f, spawnInterval * 2);
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPosition = GetRandomizedPosition();
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }

    private void SpawnCoin()
    {
        Vector3 spawnPosition = GetRandomizedPosition();
        GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomizedPosition()
    {
        float randomX = Random.Range(-xRange, xRange);

        Vector3 randomizedPosition = new(spawnPoint.position.x + randomX, spawnPoint.position.y, spawnPoint.position.z);
        return randomizedPosition;
    }
}
