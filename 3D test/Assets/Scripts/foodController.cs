using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodController : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        PhotonView PV = GetComponent<PhotonView>();
        Rigidbody rb = GetComponent<Rigidbody>();
        if (!PV.IsMine)
            return;
        rb.MovePosition(rb.position);
    }
    /*public void changeowner(Transform player)
    {
        PhotonView.TransferOwnership(gameObject,player.GetComponent<Player>());
    }*/
}
