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
    float smoothTime;
    float movingspeed = 3f, runspeed = 5f, jumpForce = 50;
    Vector3 moveAmount,smoothMoveVelocity;
    bool grouneded;
    void Awake()
    {
        PV = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();

    }

    void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }    
    }
    void Update()
    {
        if (!PV.IsMine)
            return;
        //move
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? movingspeed : runspeed ), ref smoothMoveVelocity, smoothTime);

        //jump
        /*if(Input.GetKeyDown(KeyCode.Space) && grouneded)
        {
            rb.AddForce(transform.up * jumpForce);
        }*/
    }

    void FixedUpdate()
    {
        if (!PV.IsMine)
            return;
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    
}
