using Photon.Pun;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using ExitGames.Client.Photon;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPunCallbacks
{
    Rigidbody rb;
    PhotonView PV;
    float smoothTime , verticalLookRotation;
    float movingspeed = 3f, runspeed = 5f, mouseSensitivity = 30;
    Vector3 moveAmount,smoothMoveVelocity;
    bool grouneded;
    bool isnull;
    GameObject dish;
    public Transform dish_tf;
    public string dish_name;
    [SerializeField] GameObject cameraholder;
    PickUp pickup;
    GameObject Manager;
    // Update is called once per frame
    void Awake()
    {
        PV = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        Manager = GameObject.Find("Manager");
        pickup = Manager.GetComponent<PickUp>();
    }

    void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
        isnull = true;
        //dish = GameObject.Find("Cube (1)");
        //dish_tf = dish.GetComponent<Transform>();
    }
    void Update()
    {
        if (!PV.IsMine)
            return;
        //move
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? movingspeed : runspeed ), ref smoothMoveVelocity, smoothTime);
        //pickUP
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isnull == true)
            {
                dish = pickup.Finditems(transform);
                
                if(dish != null)
                {
                    dish_tf = dish.GetComponent<Transform>();
                    dish_name = dish.name;
                    isnull = false;
                    dish_tf.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 2);
                    Hashtable hash = new Hashtable();
                    hash.Add("dish_name", dish_name);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
                    hash.Clear();
                }
            }
            else
            {
                isnull = true;
                pickup.putdown(dish_tf);
                dish = null;
                dish_tf = null;
                dish_name = "empty";
                Hashtable hash_clear = new Hashtable();
                hash_clear.Add("dish_name", dish_name);
                PhotonNetwork.LocalPlayer.SetCustomProperties(hash_clear);
                hash_clear.Clear();
            }
        }
        if (isnull == false && dish_tf != null)
        {
            dish_tf.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 2);
        }
        //float x = mouseSensitivity * Input.GetAxis("Mouse X");
        
        cameraholder.transform.rotation = Quaternion.Euler(45, 0, 0);
        cameraholder.transform.position = transform.position + new Vector3(0, 4, -4);
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if(!PV.IsMine && (targetPlayer == PV.Owner) )
        {
            dish = GameObject.Find((string)changedProps["dish_name"]);
            if(dish != null)
            {
                dish_tf = dish.GetComponent<Transform>();
                dish_name = dish.name;
            }
            else
            {
                dish_tf = null;
                dish_name = "";
            }
        }
    }
    void FixedUpdate()
    {
        if (!PV.IsMine)
            return;
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }


}
