using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{

    [SerializeField]
    float jumpPower = 10;
    [SerializeField]
    float doubleJumpMultiplier;

    Rigidbody rb;

    GroundCheck groundCheck;

    [SerializeField]
    float jumpKeeper = 1;
    float jumpKeeperLimit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();

        jumpKeeperLimit = jumpKeeper;
    }
    public void JumpInput(InputAction.CallbackContext context)
    {   
        if (groundCheck.GroundedCheck() && context.phase == InputActionPhase.Started)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
            jumpKeeper = 0;
        }
        else if (context.started && jumpKeeper != jumpKeeperLimit)
        {
            jumpKeeper++;
            rb.velocity = new Vector3(rb.velocity.x, jumpPower * doubleJumpMultiplier, rb.velocity.z);
        }
    }
}
