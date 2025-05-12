using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject characterSelectionUI;
    [SerializeField] private GameObject enemyWinText;
    [SerializeField] private GameObject playerWinText;
    private string selectedCharacter;

    [SerializeField] GameObject canvasEndGame;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        characterSelectionUI.SetActive(false);
    }
    
    public void Restart()
    {
        Time.timeScale = 1;
        playerWinText.SetActive(false);
        enemyWinText.SetActive(false);
        canvasEndGame.SetActive(false);
        characterSelectionUI.SetActive(true);
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.JoinLobby();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connecté au Master Server, en attente de rejoindre le lobby...");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Rejoint le Lobby. Vous pouvez maintenant choisir votre personnage.");
        characterSelectionUI.SetActive(true);
    }

    public void SetCharacter(string character)
    {
        selectedCharacter = character;

        
        if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
            characterSelectionUI.SetActive(false);
        }
        else
        {
            Debug.LogError("Pas encore dans le lobby, impossible de rejoindre une salle !");
        }
    }

    
    public override void OnJoinedRoom()
    {
        Debug.Log("Rejoint la salle. Instanciation du personnage.");

        Vector3 spawnPosition = new Vector3(-7, -3, 0);
        string prefabToSpawn = selectedCharacter == "Player" ? "Player" : "EnemyPlayer";
    
        GameObject playerObject = PhotonNetwork.Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        GameObject cameraObject = Instantiate(Resources.Load<GameObject>("CameraPrefab"));
    
        CameraFollow cameraFollow = cameraObject.GetComponent<CameraFollow>();
        if (cameraFollow != null)
        {
            cameraFollow.SetTarget(playerObject.transform);
        }
        else
        {
            Debug.LogError("CameraFollow script manquant sur le prefab de la caméra !");
        }
    }

}