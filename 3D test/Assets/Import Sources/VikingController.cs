using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]//won't be deleted
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]

public class VikingController : MonoBehaviour
{
    public Vector3 MovingDirection;
    MeshRenderer mr;
    [SerializeField] float movingSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Vector3 torqueDirection;
    [SerializeField] float torqueForce;
    Rigidbody rb;
    Animator animator;
    AudioSource footStep;
    bool run;
    bool stab;
    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        footStep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //run
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += movingSpeed * Time.deltaTime * transform.forward; //* mean
            run = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += movingSpeed * Time.deltaTime * -transform.forward; //* mean
            //animator.SetFloat("speed", 1f);
            run = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += movingSpeed * Time.deltaTime * -transform.right; //* mean
            run = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += movingSpeed * Time.deltaTime * transform.right; //* mean
            //animator.SetFloat("speed", 1f);
            run = true;
        }
        animator.SetBool("b_run", run);
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
    private void OnCollisionStay(Collision collision)
    {
        animator.SetBool("b_jump", false);
        if (collision.transform.tag == "ground")
        {
           // Debug.Log("hit the ground");
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(jumpForce * Vector3.up);//* mean
               
            }
        }
    }


}
