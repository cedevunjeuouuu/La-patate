using UnityEngine;
using Photon.Pun;

public class PlayerNetworkSync : MonoBehaviourPun, IPunObservable
{
    private Vector3 latestPos;
    private Vector2 latestVelocity;
    private float latestRotationZ;
    
    private Rigidbody2D rb;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) Debug.LogError("Rigidbody2D manquant sur " + gameObject.name);
    }


    void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            // Appliquer une interpolation fluide
            transform.position = Vector3.Lerp(transform.position, latestPos, Time.deltaTime * 10);
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, latestVelocity, Time.deltaTime * 10);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, latestRotationZ), Time.deltaTime * 10);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {

            stream.SendNext(transform.position);
            stream.SendNext(rb.linearVelocity);
            stream.SendNext(transform.rotation.eulerAngles.z);
        }
        else
        {

            latestPos = (Vector3)stream.ReceiveNext();
            latestVelocity = (Vector2)stream.ReceiveNext();
            latestRotationZ = (float)stream.ReceiveNext();
        }
    }
}
