using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatNBob : MonoBehaviour
{    
    [SerializeField]
    float sinOffset = 5;

    [SerializeField]
    float sinAmplification = 0.05f;

    [SerializeField]
    float sinFrequency = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, sinAmplification * Mathf.Sin(Time.time * sinFrequency + sinOffset), 0);
        transform.Rotate(0, 0.05f, 0);
    }
}
