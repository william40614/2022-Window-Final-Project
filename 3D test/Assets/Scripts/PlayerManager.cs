using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    PhotonView pv;
    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (pv.IsMine)
        {
           CreateController();
        }
    }

    // Update is called once per frame
    public void CreateController()
    {
        PhotonNetwork.Instantiate(Path.Combine("photonprefabs", "PlayerAvatar"), Vector3.zero, Quaternion.identity).GetComponent<PlayerController>();
        //instanstiate our player collecter

    }
}
