using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // SerializeField lets the editor see the private value, without other scripts seeing it.
    // A public variable would be needed in that case.
    [SerializeField]
    public float _moveSpeed = 5f;
    [SerializeField]
    private float _gravity = 9.81f;
    [SerializeField]
    private float _jumpSpeed = 3.5f;
    private CharacterController _controller;

    private Vector3 respawn = new Vector3(0, 0, 0);

    private float _directionY;

    private bool _canDoubleJump = false;

    [SerializeField]
    private float _doubleJumpMultiplier = 0.5f;

    public Timer timey;

    private Text default_timey;

    private bool respawning = false;

    public GameObject all_boosts;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
            Cursor.lockState = CursorLockMode.None;
        }
        float horizontalInput;
        float verticalInput;
        if (!respawning)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
        else
        {
            horizontalInput = 0;
            verticalInput = 0;
        }

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

        _controller.Move(transform.TransformDirection(direction * _moveSpeed * Time.deltaTime));

        if (transform.position.y <-50)
        {
            all_boosts.SetActive(true);
            int boost_count = 1;
            for (int i = 0; i < boost_count; i++)
            {
                all_boosts.transform.GetChild(i).gameObject.SetActive(true);
            }
            transform.position = respawn + new Vector3(0, 50, 0);
            respawning = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            respawning = false;
        }
        if (other.tag == "Boost")
        {
            _canDoubleJump = true;
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
            _directionY = _jumpSpeed;
            _directionY -= _gravity * Time.deltaTime;
            Vector3 boost_direction = new Vector3(0, 0, 0);
            boost_direction.y = _directionY;
            _controller.Move(transform.TransformDirection(boost_direction * _moveSpeed * Time.deltaTime));
        }
    }
}
