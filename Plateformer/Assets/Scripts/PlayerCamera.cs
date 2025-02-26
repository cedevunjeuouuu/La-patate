using UnityEngine;
using Mirror;

public class PlayerCamera : NetworkBehaviour
{
    public GameObject cameraPrefab;
    private GameObject cameraInstance;
    public override void OnStartLocalPlayer()
    {
        if (isLocalPlayer) 
        {
            cameraInstance = Instantiate(cameraPrefab);
            cameraInstance.GetComponent<CameraMoov>().target = this.transform;
        }
    }
}