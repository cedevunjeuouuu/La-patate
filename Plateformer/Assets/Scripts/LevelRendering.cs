using Photon.Pun;
using UnityEngine;

public class LevelRendering : MonoBehaviour
{
    [SerializeField] private string[] chunkPrefabs;
    [SerializeField] private int numberMaxOfChunk;
    [SerializeField]private Transform FirstPositionLevel;
    [SerializeField]private Transform LevelParent;
    [SerializeField] private Transform levelEnd;
    private Transform lastEndPoint;
    

    private void DestroyLastLevel()
    {
        foreach (Transform children in LevelParent)
        {
            Destroy(children.gameObject);
        }
    }
   private  void SpawnFirstChunk()
    {
        GameObject firstChunk = PhotonNetwork.Instantiate(chunkPrefabs[0],FirstPositionLevel.position,new Quaternion());
        Chunk chunk = firstChunk.GetComponent<Chunk>();
        firstChunk.transform.localScale = Vector3.one;
        Transform startPoint = chunk.StartPoint;
        if (startPoint == null)
        {
            Debug.LogWarning("First chunk is missing StartPoint");
            return;
        }
        
        Vector3 offset = FirstPositionLevel.position - startPoint.position;
        
        firstChunk.transform.position += offset;
        
        lastEndPoint = chunk.endPoint;
    }

    public void CreateLevel()
    {
        DestroyLastLevel();
        SpawnFirstChunk();
        for (int i = 0; i < numberMaxOfChunk; i++)
        {
            SpawnNextChunk(i);
        }
    }

    private void SpawnNextChunk(int chunkNumber)
    {
        
        int index = Random.Range(0, chunkPrefabs.Length);
        GameObject newChunk = PhotonNetwork.Instantiate(chunkPrefabs[index],FirstPositionLevel.position,new Quaternion());
        Chunk chunk = newChunk.GetComponent<Chunk>();
        
        
        Transform startPoint = chunk.StartPoint;
        if (startPoint == null || lastEndPoint == null)
        {
            Debug.LogWarning("Chunk is missing StartPoint or last chunk is missing EndPoint");
            return;
        }
        
        Vector3 offset = lastEndPoint.position - startPoint.position;
        
        
        
        newChunk.transform.position += offset;
        
        lastEndPoint = chunk.endPoint;
        
        levelEnd.position = lastEndPoint.position;
    }
}
