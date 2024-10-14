using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityCap : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float maxVelocity = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, maxVelocity * -1, maxVelocity), rb.velocity.y, Mathf.Clamp(rb.velocity.z, maxVelocity * -1, maxVelocity));
    }
}
