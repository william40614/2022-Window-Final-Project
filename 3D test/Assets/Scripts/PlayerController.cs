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
    float movingspeed = 10f, runspeed = 5f, mouseSensitivity = 30;
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
        float yVelocity = 0.0F;
        if (!PV.IsMine)
            return;
        /*float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.MovePosition(this.transform.position + new Vector3(h, 0, v) * movingspeed * Time.deltaTime);
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Vector3 targetDirection = new Vector3(h, 0f, v);
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up); 
            Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, movingspeed * Time.deltaTime);
            rb.MoveRotation(newRotation);
        }*/
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
            transform.position = new Vector3(transform.position.x+ movingspeed, transform.position.y, transform.position.z);
        }
        else if(Input.GetKeyDown(KeyCode.W))
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (Input.GetKeyDown(KeyCode.S))
            transform.eulerAngles = new Vector3(0,180, 0);
        else if (Input.GetKeyDown(KeyCode.D))
            transform.eulerAngles = new Vector3(0,90, 0);*/
        //move
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0, -45, 0);
            transform.Translate(new Vector3(-1, 0, 1) * movingspeed * Time.deltaTime, Space.World);
            if (dish_tf != null)
                dish_tf.position = new Vector3(transform.position.x - 1, transform.position.y + 1, transform.position.z + 1);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0, 45, 0);
            transform.Translate(new Vector3(1, 0, 1) * movingspeed * Time.deltaTime, Space.World);
            if (dish_tf != null)
                dish_tf.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z + 1);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0, -135, 0);
            transform.Translate(new Vector3(-1, 0, -1) * movingspeed * Time.deltaTime, Space.World);
            if (dish_tf != null)
                dish_tf.position = new Vector3(transform.position.x - 1, transform.position.y + 1, transform.position.z - 1);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0, 135, 0);
            transform.Translate(new Vector3(1, 0, -1) * movingspeed * Time.deltaTime, Space.World);
            if (dish_tf != null)
                dish_tf.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z - 1);
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                transform.Translate(Vector3.forward * movingspeed * Time.deltaTime, Space.World);
                if (dish_tf != null)
                    dish_tf.position = new Vector3(transform.position.x , transform.position.y + 1, transform.position.z  + 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                transform.Translate(Vector3.back * movingspeed * Time.deltaTime, Space.World);
                if (dish_tf != null)
                    dish_tf.position = new Vector3(transform.position.x , transform.position.y + 1, transform.position.z - 1);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.localRotation = Quaternion.Euler(0, -90, 0);
                transform.Translate(Vector3.left * movingspeed * Time.deltaTime, Space.World);
                if (dish_tf != null)
                    dish_tf.position = new Vector3(transform.position.x - 1 , transform.position.y + 1, transform.position.z );
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.localRotation = Quaternion.Euler(0, 90, 0);
                transform.Translate(Vector3.right * movingspeed * Time.deltaTime, Space.World);
                if(dish_tf != null)
                    dish_tf.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
            }
        }
        //Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        //moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? movingspeed : runspeed ), ref smoothMoveVelocity, smoothTime);
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
        /*if (isnull == false && dish_tf != null)
        {
            dish_tf.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 2);
        }*/
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
        //rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
        
    }


}
