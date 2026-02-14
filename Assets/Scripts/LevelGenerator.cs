using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private Transform chunkParent;
    [SerializeField] private int initialChunkAmount = 10;
    [SerializeField] private int chunkLength = 10;
    [SerializeField] private float moveSpeed = 10f;

    private List<GameObject> chunks = new List<GameObject>();

    private Camera mainCamera;
    private GameManager gameManager;

    private void Awake()
    {
        mainCamera = Camera.main;
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Start()
    {
        SpawnInitialChunks();
    }

    private void Update()
    {
        if (gameManager != null && !gameManager.IsGameActive)
            return;

        MoveChunks();
    }

    private void SpawnInitialChunks()
    {
        for (int i = 0; i < initialChunkAmount; i++)
        {
            SpawnChunkAtIndex(i);
        }
    }

    private void SpawnChunkAtIndex(int index)
    {
        float chunkZ = (index * chunkLength) + transform.position.z;

        Vector3 chunkPos = new Vector3(
            transform.position.x,
            transform.position.y,
            chunkZ
        );

        GameObject newChunk = Instantiate(
            chunkPrefab,
            chunkPos,
            Quaternion.identity,
            chunkParent
        );

        chunks.Add(newChunk);
    }

    private void SpawnNewChunk()
    {
        float chunkZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;

        Vector3 chunkPos = new Vector3(
            transform.position.x,
            transform.position.y,
            chunkZ
        );

        GameObject newChunk = Instantiate(
            chunkPrefab,
            chunkPos,
            Quaternion.identity,
            chunkParent
        );

        chunks.Add(newChunk);
    }

    private void MoveChunks()
    {
        float destroyZ = mainCamera.transform.position.z - chunkLength;

        for (int i = chunks.Count - 1; i >= 0; i--)
        {
            GameObject chunk = chunks[i];

            chunk.transform.Translate(
                -transform.forward * moveSpeed * Time.deltaTime
            );

            if (chunk.transform.position.z <= destroyZ)
            {
                Destroy(chunk);
                chunks.RemoveAt(i);
                SpawnNewChunk();
            }
        }
    }
}