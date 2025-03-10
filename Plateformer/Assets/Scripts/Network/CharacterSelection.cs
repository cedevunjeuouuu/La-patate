using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public NetworkManager networkManager;

    public void SelectPlayer()
    {
        networkManager.SetCharacter("Player");
    }

    public void SelectEnemy()
    {
        networkManager.SetCharacter("Enemy");
    }
}