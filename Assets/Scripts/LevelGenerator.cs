using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] GameObject chunkParent;
    [SerializeField] int initialChunkAmount = 10;
    [SerializeField] int chunkLength = 10;
    [SerializeField] float moveSpeed = 10;

    List<GameObject> chunks = new List<GameObject>();
    //GameObject[] chunks = new GameObject[10];

    private void Start()
    {
        SpawnChunk();
    }
    private void Update()
    {
        MoveChunk();
    }

    private void SpawnChunk()
    {
        for (int i = 0; i < initialChunkAmount; i++)
        {
            float chunkZ;
            chunkZ = (i * chunkLength) + transform.position.z;
            Vector3 chunkPos = new Vector3(transform.position.x, transform.position.y, chunkZ);
            GameObject newChunk = Instantiate(chunkPrefab, chunkPos, Quaternion.identity, chunkParent.transform);
            chunks.Add(newChunk);
        }
    }

    private void SpawnNewChunk()
    {
        float chunkZ;
        chunkZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        Vector3 chunkPos = new Vector3(transform.position.x, transform.position.y, chunkZ);
        GameObject newChunk = Instantiate(chunkPrefab, chunkPos, Quaternion.identity, chunkParent.transform);
        chunks.Add(newChunk);
    }

    private void MoveChunk()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * moveSpeed * Time.deltaTime);
            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnNewChunk();
            }
        }
    }
}
