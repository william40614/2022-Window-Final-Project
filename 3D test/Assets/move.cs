using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Vector3 MovingDirection;
    Rigidbody rb;
    [SerializeField] float movingSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Vector3 torqueDirection;
    [SerializeField] float torqueForce;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //run
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += movingSpeed * Time.deltaTime * transform.forward; //* mean
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += movingSpeed * Time.deltaTime * -transform.forward; //* mean
            //animator.SetFloat("speed", 1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += movingSpeed * Time.deltaTime * -transform.right; //* mean
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += movingSpeed * Time.deltaTime * transform.right; //* mean
            //animator.SetFloat("speed", 1f);
        }
        //direction
        if (Input.GetKey(KeyCode.F))//turn left
        {
            rb.AddTorque(torqueDirection * torqueForce);
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.G))//turn right
        {
            rb.AddTorque(torqueDirection * torqueForce);
            transform.Rotate(0, 1, 0);
        }
        //
    }
}
