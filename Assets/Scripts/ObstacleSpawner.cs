using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float spawnWidth = 3f;
    [SerializeField] private Transform obstacleParent;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (gameManager != null && !gameManager.IsGameActive)
                yield break;

            SpawnObstacle();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnObstacle()
    {
        if (obstacles.Length == 0) return;

        GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];

        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnWidth, spawnWidth),
            transform.position.y,
            transform.position.z
        );

        Instantiate(obstacle, spawnPosition, Quaternion.identity, obstacleParent);
    }
}
