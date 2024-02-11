using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _FallVelocity = 0;

    public float gravity = 9.8f;

    public float JumpForce;

    private CharacterController _characterController;

    public float PlayerSpeed;

    private Vector3 _moveVector;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W)))
        {
            _moveVector += transform.forward * 2;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _FallVelocity = -JumpForce;
        }
    }
    void FixedUpdate()

    {
        //Movement
        _characterController.Move(_moveVector * PlayerSpeed * Time.fixedDeltaTime);

        //Fall and jump
        _FallVelocity += gravity * Time.fixedDeltaTime;

        _characterController.Move(Vector3.down * _FallVelocity * Time.fixedDeltaTime);

        //Stop fall if on the ground
        if (_characterController.isGrounded)
        {
            _FallVelocity = 0;
        }
    }

    
}
