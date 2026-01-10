using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Obstacles;
    [SerializeField] int numToSpawn = 10;
    [SerializeField] int waitPerSpawn = 1;
    [SerializeField] float spawnWidth = 3f;
    [SerializeField] GameObject ObstacleParent;

    private void Start()
    {
        //for (int i = 0; i < numToSpawn; i++)
        //{
        //    Instantiate(Obstacle, transform.position, Quaternion.identity);
        //}
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (numToSpawn > 0)
        {
            yield return new WaitForSeconds(waitPerSpawn);
            GameObject Obstacle = Obstacles[Random.Range(0, Obstacles.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, +spawnWidth), transform.position.y, transform.position.z);
            Instantiate(Obstacle, spawnPosition, Random.rotation, ObstacleParent.transform);
            numToSpawn--;
        }
    }
}
