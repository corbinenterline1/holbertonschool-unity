using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // SerializeField lets the editor see the private value, without other scripts seeing it.
    // A public variable would be needed in that case.
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _gravity = 9.81f;
    [SerializeField]
    private float _jumpSpeed = 3.5f;
    private CharacterController _controller;

    private float _directionY;

    private bool _canDoubleJump = false;

    [SerializeField]
    private float _doubleJumpMultiplier = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        if (_controller.isGrounded)
        {
            _canDoubleJump = true;
            if(Input.GetButtonDown("Jump")) 
            {
                _directionY = _jumpSpeed;
            }
        } else 
        {
            if(Input.GetButtonDown("Jump") && _canDoubleJump) 
            {
                _directionY = _jumpSpeed * _doubleJumpMultiplier;
                _canDoubleJump = false;
            }
        }

        _directionY -= _gravity * Time.deltaTime;
        
        direction.y = _directionY;

        _controller.Move(direction * _moveSpeed * Time.deltaTime);
    }
}
