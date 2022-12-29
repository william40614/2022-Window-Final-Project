using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    PhotonView pv;
    int number_player;
    GameObject Manager;
    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (pv.IsMine)
        {
            Manager = GameObject.Find("Manager");
            CreateController();
        }
    }

    // Update is called once per frame
    public void CreateController()
    {
        GameObject player =  PhotonNetwork.Instantiate(Path.Combine("photonprefabs", "PlayerAvatar"), Vector3.zero, Quaternion.identity);
        if(GameObject.Find("player1")!=null)
            player.name = "player2";
        else
            player.name = "player1";
        //instanstiate our player collecter
        Debug.Log(player.name);

    }
}
