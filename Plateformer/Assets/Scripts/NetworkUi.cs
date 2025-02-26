using UnityEngine;
using Mirror;
using TMPro;

public class NetworkUI : MonoBehaviour
{
    public TMP_InputField ipInputField;
    public NetworkManager networkManager;

    public void StartHost()
    {
        networkManager.StartHost();
    }

    public void StartClient()
    {
        string ip = ipInputField.text; // Récupérer l'IP entrée
        networkManager.networkAddress = ip; // Définir l'IP du serveur
        networkManager.StartClient(); // Se connecter au serveur
    }
}