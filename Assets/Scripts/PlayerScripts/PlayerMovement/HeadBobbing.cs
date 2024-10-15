using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour
{
    [SerializeField]
    float sinOffset = 0;

    [SerializeField]
    float sinAmplification = 0.05f;

    [SerializeField]
    float sinFrequency = 10f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.localPosition = new Vector3(0, sinAmplification * Mathf.Sin(Time.time * sinFrequency) + sinOffset, 0);
    }
}
