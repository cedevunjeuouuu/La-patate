using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    [SerializeField] private GameObject enemyCharacterPrefab;

    public override void Start()
    {
        Debug.Log("Serveur écoutant sur : " + networkAddress);
    }
    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkServer.RegisterHandler<CharacterSelectionMessage>(OnCharacterSelected);
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // Ne pas ajouter de joueur immédiatement, attendre la sélection
    }

    private void OnCharacterSelected(NetworkConnectionToClient conn, CharacterSelectionMessage message)
    {
        GameObject prefabToSpawn = message.characterType == "player" ? playerPrefab : enemyCharacterPrefab;

        GameObject playerInstance = Instantiate(prefabToSpawn);
        NetworkServer.AddPlayerForConnection(conn, playerInstance);
    }
}

public struct CharacterSelectionMessage : NetworkMessage
{
    public string characterType;
}
