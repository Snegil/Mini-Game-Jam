using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
    float setMovementSpeed;
    float movementMultiplier;
    bool move = false;
    public bool Move { get { return move; } set { move = value; } }
     
    Vector3 movementInput = Vector3.zero;

    Rigidbody rb;

    GroundCheck groundCheck;
    void Start()
    {
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }

        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();
        setMovementSpeed = movementSpeed;
    }

    void FixedUpdate()
    {
        if (groundCheck.GroundedCheck())
        {
            movementMultiplier = 1f;
        }
        if (!groundCheck.GroundedCheck()) 
        {
            movementMultiplier = 0.5f;
        }

        if (move)
        {
            rb.AddRelativeForce(movementMultiplier * movementSpeed * movementInput, ForceMode.VelocityChange);
            //rb.velocity = new Vector3(0, 0, movementInput.z * movementSpeed);
        }
    }

    public void MovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector3>();

        if (context.started)
        {
            move = true;
        }
        if (context.canceled)
        {
            move = false;
            rb.velocity = new(rb.velocity.x / 2, rb.velocity.y, rb.velocity.z / 2);
        }
    }

    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
}
