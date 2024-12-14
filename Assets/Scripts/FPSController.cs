using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))] //this is a great thing to show people as it shows them how to make sure components will set up on objects.
public class FPSController : MonoBehaviour
{
    private float _xRotation;
    private Vector3 _moveVector;
    private CharacterController _controller;
    [SerializeField] private float mouseSensitivity = 200f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private Camera camera;
    [SerializeField] private float xCameraBounds = 60f;
    private bool _hasJumped;
    
    #region Smoothing code
    private Vector2 _currentMouseDelta;
    private Vector2 _currentMouseVelocity;
    [SerializeField] private float smoothTime = .1f;
    
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {

        
        if (_controller.isGrounded && _moveVector.y < 0)
        {
            _moveVector.y = 0f;
            _hasJumped = false;
        }

        Vector3 move = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        _controller.Move(move * Time.deltaTime * speed);

        // Makes the player jump
        if (Input.GetButtonDown("Jump") && !_hasJumped)
        {
            _moveVector.y += Mathf.Sqrt(jumpForce * -2.0f * gravityValue);
            _hasJumped = true;
        }

        _moveVector.y += gravityValue * Time.deltaTime;
        _controller.Move(_moveVector * Time.deltaTime);
    }

    private void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        Vector2 targetDelta = new Vector2(mouseX, mouseY);
        _currentMouseDelta = Vector2.SmoothDamp(_currentMouseDelta, targetDelta, ref _currentMouseVelocity, smoothTime);
        _xRotation -= _currentMouseDelta.y;
        _xRotation = Mathf.Clamp(_xRotation, -xCameraBounds, xCameraBounds);
        transform.Rotate(Vector3.up * _currentMouseDelta.x);
        camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }

    private void LateUpdate()
    {

        
    }
}
