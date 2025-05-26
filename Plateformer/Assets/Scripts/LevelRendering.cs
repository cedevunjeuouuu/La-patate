using UnityEngine;

public class LevelRendering : MonoBehaviour
{
    [SerializeField] private Chunk[] chunkPrefabs;
    [SerializeField] private int numberMaxOfChunk;
    [SerializeField]private Transform FirstPositionLevel;
    [SerializeField]private Transform LevelParent;
    private Transform lastEndPoint;
    
    void Start()
    {
        CreateLevel();
        
    }

    private void DestroyLastLevel()
    {
        foreach (Transform children in LevelParent)
        {
            Destroy(children.gameObject);
        }
    }
   private  void SpawnFirstChunk()
    {
        Chunk firstChunk = Instantiate(chunkPrefabs[0], LevelParent);
        Transform startPoint = firstChunk.StartPoint;
        if (startPoint == null)
        {
            Debug.LogWarning("First chunk is missing StartPoint");
            return;
        }
        
        Vector3 offset = FirstPositionLevel.position - startPoint.position;
        
        firstChunk.transform.position += offset;
        
        lastEndPoint = firstChunk.endPoint;
    }

    public void CreateLevel()
    {
        DestroyLastLevel();
        SpawnFirstChunk();
        for (int i = 0; i < numberMaxOfChunk; i++)
        {
            SpawnNextChunk();
        }
        
    }

    private void SpawnNextChunk()
    {
        int index = Random.Range(0, chunkPrefabs.Length);
        Chunk newChunk = Instantiate(chunkPrefabs[index],LevelParent);

        Transform startPoint = newChunk.StartPoint;
        if (startPoint == null || lastEndPoint == null)
        {
            Debug.LogWarning("Chunk is missing StartPoint or last chunk is missing EndPoint");
            return;
        }
        
        Vector3 offset = lastEndPoint.position - startPoint.position;
        
        newChunk.transform.position += offset;
        
        lastEndPoint = newChunk.endPoint;
    }
}
