using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GroundCheck : MonoBehaviour
{
    [SerializeField, Header("Length of raycast downwards.")]
    float distance = 1f;
    [SerializeField, Header("Which layer to hit.")]
    LayerMask layerMask;

    void Update() 
    {
        Debug.DrawRay(transform.position, Vector3.down * distance, Color.green);
        
    }
    public bool GroundedCheck()
    {
        if(Physics.Raycast(transform.position - new Vector3(0, (float)-0.5, 0), Vector3.down, out RaycastHit hit, distance, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
