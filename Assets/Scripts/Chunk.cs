using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private float[] lanes = { -3, 0, 3 };
    [SerializeField] private GameObject fence;
    [SerializeField] private GameObject coin;

    private void Start()
    {
        SpawnContent();
    }

    private void SpawnContent()
    {
        List<int> availableLanes = new List<int> { 0, 1, 2 };

        SpawnFences(availableLanes);
        SpawnCoin(availableLanes);
    }

    private void SpawnFences(List<int> availableLanes)
    {
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0)
                break;

            int randomIndex = Random.Range(0, availableLanes.Count);
            int selectedLane = availableLanes[randomIndex];

            availableLanes.RemoveAt(randomIndex);

            Vector3 spawnPosition = new Vector3(
                lanes[selectedLane],
                transform.position.y,
                transform.position.z
            );

            Instantiate(fence, spawnPosition, Quaternion.identity, transform);
        }
    }

    private void SpawnCoin(List<int> availableLanes)
    {
        if (availableLanes.Count <= 0)
            return;

        int laneIndex = availableLanes[0];

        Vector3 spawnPosition = new Vector3(
            lanes[laneIndex],
            transform.position.y + 0.7f,
            transform.position.z
        );

        Instantiate(coin, spawnPosition, Quaternion.identity, transform);
    }
}