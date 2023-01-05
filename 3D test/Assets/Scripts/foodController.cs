using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodController : MonoBehaviour
{
    [SerializeField] public GameObject controller;   // Start is called before the first frame update
    [SerializeField] public int pick = 0;
    void Update()
    {
        PhotonView PV = GetComponent<PhotonView>();
        Rigidbody rb = GetComponent<Rigidbody>();
        if (!PV.IsMine)
            return;
        rb.MovePosition(rb.position);
        /*if (Input.GetKeyDown(KeyCode.Space) && controller.name == "player1")
        {
            if (GetComponent<PhotonView>().Owner == GameObject.Find("player1").GetComponent<PhotonView>().Owner && pick == 0)
            {
                pick = 1;
            }
            else if(GetComponent<PhotonView>().Owner == GameObject.Find("player1").GetComponent<PhotonView>().Owner)
            {
                pick = 0;
            }
            else if(pick == 0)
            {
                GetComponent<PhotonView>().TransferOwnership(GameObject.Find("player1").GetComponent<PhotonView>().Owner);
                pick = 1;
            }
            else
            {
                GetComponent<PhotonView>().TransferOwnership(GameObject.Find("player1").GetComponent<PhotonView>().Owner);
                pick = 0;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space) && controller.name == "PlayerAvatarZ(Clone)")
        {
            if (GetComponent<PhotonView>().Owner == GameObject.Find("PlayerAvatarZ(Clone)").GetComponent<PhotonView>().Owner && pick == 0)
                pick = 1;
            else if (GetComponent<PhotonView>().Owner == GameObject.Find("PlayerAvatarZ(Clone)").GetComponent<PhotonView>().Owner)
                pick = 0;
            else if (pick == 0)
            {
                GetComponent<PhotonView>().TransferOwnership(GameObject.Find("PlayerAvatarZ(Clone)").GetComponent<PhotonView>().Owner);
                pick = 1;
            }
            else
            {
                GetComponent<PhotonView>().TransferOwnership(GameObject.Find("PlayerAvatarZ(Clone)").GetComponent<PhotonView>().Owner);
                pick = 0;
            }
        }*/
    }
    /*public void changeowner(Transform player)
    {
        PhotonView.TransferOwnership(gameObject,player.GetComponent<Player>());
    }*/
}
