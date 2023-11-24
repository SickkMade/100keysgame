using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void KeyboardInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void Update()
    {
        KeyboardInput();
    }

    private void MovePlayer()
    {
        //in a 3d space we are saying... forward facing direction times vI and left right direction times hI... ACCOUNTS FOR LOCALNESS :DD
        moveDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);
        rb.AddForce(moveDirection * moveSpeed);
    }

    private void FixedUpdate() //dont need time.deltatime
    {
        MovePlayer();
    }
}
