using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MoveScript : NetworkBehaviour
{

    public float speed;
    public float runSpeed;
    public Rigidbody RBplayer;
    public float jumpForce;
    private bool isGrounded;
    private SphereCollider coll;
    
    void Start()
    {
        coll = GetComponentInChildren<SphereCollider>();
    }

    private void Update()
    {
        OnTriggerEnter(coll);
        OnTriggerExit(coll);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            RBplayer.AddForce(0, jumpForce, 0);
        }
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        Vector3 move2 = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        

        if (Input.GetKey("left shift"))
        {
            RBplayer.AddForce(move2 * runSpeed);
        }
        RBplayer.AddForce(move2 * speed);
        // Debug.Log(RBplayer.velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public override void OnStartLocalPlayer()
    {
        // GetComponent<Material>().color = Color.red;
        base.OnStartLocalPlayer();
    }
}
