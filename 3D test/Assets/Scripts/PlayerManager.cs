using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

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
    void CreateController()
    {
        PhotonNetwork.Instantiate(Path.Combine("photonprefabs", "PlayerController"), Vector3.zero, Quaternion.identity);
        //instanstiate our player collecter

    }

}
