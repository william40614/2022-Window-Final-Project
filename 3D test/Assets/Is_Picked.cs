using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_Picked : MonoBehaviour
{
    public bool is_picked = false;
    PhotonView PV;
    // Start is called before the first frame updat

    public void ChangePickedTrue()
    {
        is_picked = true;
    }
    private void Start()
    {
        PV = GetComponent<PhotonView>();
    }
    public void ChangePickedFalse()
    {
        is_picked = false;
    }
}
