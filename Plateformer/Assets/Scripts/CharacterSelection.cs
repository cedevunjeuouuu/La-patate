using Mirror;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private string selectedCharacter = "player";

    public void SelectPlayer()
    {
        selectedCharacter = "player";
    }

    public void SelectEnemy()
    {
        selectedCharacter = "enemy";
    }

    public void JoinGame()
    {
        NetworkManager.singleton.StartClient();

        if (NetworkClient.active)
        {
            CharacterSelectionMessage message = new CharacterSelectionMessage
            {
                characterType = selectedCharacter
            };
            NetworkClient.Send(message);
        }
    }
}