using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    [Header("Keybinds")]
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private Rigidbody rb;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundMask;
    public Transform orientation;
    private bool DisabledMovement = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        GameEventManger.instance.playerEvents.OnChooseMimic += DisableMovment;
    }
    void OnDisable()
    {
        GameEventManger.instance.playerEvents.OnChooseMimic -= DisableMovment;
    }
    private void DisableMovment()
    {
        DisabledMovement = !DisabledMovement;
    }
    void Update()
    {


        MyInput();
        SpeedControl();


        rb.drag = groundDrag;


    }
    void FixedUpdate()
    {

        MovePlayer();

    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void MovePlayer()
    {
        if (DisabledMovement) return;
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;


        rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
