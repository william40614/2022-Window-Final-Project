using Photon.Pun;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    PhotonView PV;
    float smoothTime , verticalLookRotation;
    float movingspeed = 3f, runspeed = 5f, mouseSensitivity = 30;
    Vector3 moveAmount,smoothMoveVelocity;
    bool grouneded;
    bool isnull;
    GameObject dish;
    Transform dish_tf;
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
        dish = GameObject.Find("Cube (1)");
        dish_tf = dish.GetComponent<Transform>();
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
                    isnull = false;
                    dish_tf.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 2);
                }
            }
            else
            {
                isnull = true;
                pickup.putdown(dish_tf);
                
            }
        }
        if (isnull == false)
        {
            dish_tf.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 2);
        }
        float x = mouseSensitivity * Input.GetAxis("Mouse X");
        //以下為相機與角色同步旋轉是
        /*cameraholder.transform.rotation = Quaternion.Euler(
            cameraholder.transform.rotation.eulerAngles +
            Quaternion.AngleAxis(x, Vector3.up).eulerAngles
        );//原理： 物體當前的尤拉角 + 滑鼠x軸上的增量所產生的夾角

        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles +
            Quaternion.AngleAxis(x, Vector3.up).eulerAngles
        );//同理
        Vector3 TargetCameraPosition = transform.TransformPoint(new Vector3(0, 4.5f, -5.5f));//獲取相機跟隨的相對位置，再轉為世界座標

        cameraholder.transform.position = Vector3.SmoothDamp(
            cameraholder.transform.position,
            TargetCameraPosition,
            ref smoothMoveVelocity,
            smoothTime, //最好為0
            Mathf.Infinity,
            Time.deltaTime
        );*/
        /*
        pot1.Setbool(puttomato); 
        ...

         */
        /*transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        cameraholder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
        cameraholder.transform.localPosition = new Vector3(transform.position.x + 2, transform.position.y + 1, transform.position.z);
        */
        //jump
        /*if(Input.GetKeyDown(KeyCode.Space) && grouneded)
        {
            rb.AddForce(transform.up * jumpForce);
        }*/
        cameraholder.transform.rotation = Quaternion.Euler(45, 0, 0);
        cameraholder.transform.position = transform.position + new Vector3(0, 4, -4);
    }
    
    void FixedUpdate()
    {
        if (!PV.IsMine)
            return;
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    
}
