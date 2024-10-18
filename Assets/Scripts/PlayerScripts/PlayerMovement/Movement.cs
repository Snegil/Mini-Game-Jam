using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
    bool move = false;
    public bool Move { get { return move; } set { move = value; } }
     
    Vector3 movementInput = Vector3.zero;

    Rigidbody rb;

    void Start()
    {
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (move)
        {
            rb.AddRelativeForce(movementInput * movementSpeed);
            //rb.velocity = new Vector3(movementInput.x, 0, movementInput.z * movementSpeed);
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
            rb.velocity = new(0, 0, 0);
        }
    }

    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
}
