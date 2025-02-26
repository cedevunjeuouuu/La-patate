using Mirror;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    private bool isHost;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        isHost = isServer;
        if (isLocalPlayer)
        {
            Debug.Log("Je suis le joueur local !");
        }
    }
}