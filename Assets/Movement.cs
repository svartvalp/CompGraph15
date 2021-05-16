using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 20f;

    public float gravity = -9.8f;

    private Vector3 _velocity;

    public Transform groundCheck;

    public LayerMask groundMask;

    public float groundDistance = 0.4f;

    private bool _isGrounded;

    public float jumpForce = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        _velocity.y += gravity + Time.deltaTime;

        characterController.Move((_velocity * Time.deltaTime) / 2);

        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

    }
}
