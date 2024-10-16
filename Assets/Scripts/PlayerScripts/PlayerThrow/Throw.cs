using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Throw : MonoBehaviour
{
    [SerializeField]
    float throwMultiplier;
    [SerializeField]
    float throwForce;

    [SerializeField]
    GameObject rockToInstantiate;

    [SerializeField]
    GameObject rockInHand;

    bool hasRock = true;

    [Space, SerializeField]
    Animator anim;

    // Update is called once per frame
    void Update()
    {
        anim.Play("Throw", 0, Mathf.Clamp(throwMultiplier, 0, 0.99f));
    }

    public void ThrowMultiplier(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            throwMultiplier += context.ReadValue<float>() / 20000;
            throwMultiplier = Mathf.Clamp(throwMultiplier, 0, 1);  
        }
    }
    public void ThrowRock(InputAction.CallbackContext context)
    {
        anim.Play("Throw", 0, 0);

        if (hasRock)
        {
            GameObject instantiated = Instantiate(rockToInstantiate, rockInHand.transform.position, quaternion.identity, null);
            instantiated.GetComponent<Rigidbody>().AddForce(Camera.main.gameObject.transform.forward * throwMultiplier * throwForce);

            hasRock = false;
            rockInHand.SetActive(false);   
        }

        throwMultiplier = 0;
    }

    public void ReloadRock()
    {
        hasRock = true;
        rockInHand.SetActive(true);
    }
}
