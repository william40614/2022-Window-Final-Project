using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodController : MonoBehaviour
{
    // Start is called before the first frame update
    void FixedUpdate()
    {
        PhotonView PV = GetComponent<PhotonView>();
        Rigidbody rb = GetComponent<Rigidbody>();
        if (!PV.IsMine)
            return;
        rb.MovePosition(rb.position);
    }
}
