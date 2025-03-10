using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject characterSelectionUI; // Associe ton UI dans l'inspecteur
    private string selectedCharacter;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        characterSelectionUI.SetActive(false); // Désactive l'UI au départ
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connecté au Master Server, en attente de rejoindre le lobby...");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Rejoint le Lobby. Vous pouvez maintenant choisir votre personnage.");
        characterSelectionUI.SetActive(true); // Active l'UI de sélection de personnage
    }

    public void SetCharacter(string character)
    {
        selectedCharacter = character;

        // Assure-toi d'être bien dans le lobby avant de tenter de rejoindre une salle
        if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
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
    
        // Instanciation du personnage
        GameObject playerObject = PhotonNetwork.Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Instanciation de la caméra
        GameObject cameraObject = Instantiate(Resources.Load<GameObject>("CameraPrefab"));
    
        // Assigner la cible à la caméra
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