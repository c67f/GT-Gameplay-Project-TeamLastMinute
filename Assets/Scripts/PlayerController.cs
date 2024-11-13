using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform orientation;
    public float playerHeight;
    Rigidbody thisRB;
    float h = 0f;
    float v = 0f;

    public float playerSpeed;// = 40f;
    public float groundDrag;
    public float jumpPower;// = new Vector3(0f, 100f, 0f);

    //looking around vars
    [SerializeField] private float mouseSensitivity = 2.0f;
    [SerializeField] private float upDownRange = 80.0f;
    [SerializeField] private string MouseXInput = "Mouse X";
    [SerializeField] private string MouseYInput = "Mouse Y";
    float verticalRotation;
    public Camera mainCamera;
    
    Vector3 moveDirection;
    //Vector3 moveForce = Vector3.zero;
    //Vector3 jumpForce = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        thisRB = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        MoveInput();
        SpeedControl();
        HandleRotation();

        /*if (IsGrounded())
        {
            thisRB.drag = groundDrag;
            //Debug.Log(thisRB.drag);
        } else
        {
            thisRB.drag = 0;
        }*/
        //Vector3 xForce = new Vector3(h, 0f, 0f);
        //Vector3 zForce = new Vector3(0f, 0f, v);
        //moveForce = xForce + zForce;
        //Debug.Log(xForce);
        //Debug.Log(zForce);
        //Debug.Log(xForce+zForce);

        //Jump:
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Debug.Log("is jumping");
            Jump();
        } /*else
        {
            jumpForce = Vector3.zero;
        }*/

    }

    private void FixedUpdate()
    {

        //Vector3 totalForce = moveForce + jumpForce;
        //Debug.Log(totalForce);
        MovePlayer();

    }

    private void MoveInput()
    {

        h = Input.GetAxis("Horizontal") * playerSpeed;
        v = Input.GetAxis("Vertical") * playerSpeed;
        Debug.Log(Mathf.Abs(h));
    }

    private void MovePlayer()
    {
        //Movement:
        moveDirection = orientation.forward * v + orientation.right * h; //AddRelativeForce vs. orientation.forward and orientation.right?
        thisRB.AddForce(moveDirection * playerSpeed, ForceMode.Force);
        /*if (Mathf.Abs(h) < 0.01)
        {
            Debug.Log(Mathf.Abs(h));
            Debug.Log("stoppping player");
            thisRB.velocity = new Vector3(0, thisRB.velocity.y, thisRB.velocity.z);
        }
        if (Mathf.Abs(v) < 0.01)
        {
            thisRB.velocity = new Vector3(thisRB.velocity.x, thisRB.velocity.y, 0);
        }*/
        //Debug.Log(moveDirection);
    }

    private void HandleRotation()
    {
        float mouseXRotation = Input.GetAxis(MouseXInput) * mouseSensitivity;
        transform.Rotate(0, mouseXRotation, 0);
        verticalRotation -= Input.GetAxis(MouseYInput) * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * (playerHeight * 0.5f + 0.2f));
        return Physics.Raycast(transform.position, Vector3.down, (playerHeight / 2f) + 0.2f);
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(thisRB.velocity.x, 0f, thisRB.velocity.z);

        if(flatVelocity.magnitude > playerSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * playerSpeed;
            thisRB.velocity = new Vector3(limitedVelocity.x, thisRB.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump()
    {
        thisRB.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        //Debug.Log(jumpForce);
    }
}
