using Photon.Pun;
using UnityEngine;

public class NetworkPlayer : MonoBehaviourPun
{
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    void Update()
    {
        if (photonView.IsMine)
        {
            photonView.RPC("UpdatePosition", RpcTarget.Others, transform.position, transform.rotation);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10);
        }
    }

    [PunRPC]
    void UpdatePosition(Vector3 pos, Quaternion rot)
    {
        targetPosition = pos;
        targetRotation = rot;
    }
}