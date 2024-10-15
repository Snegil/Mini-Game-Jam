using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Throw : MonoBehaviour
{
    [SerializeField]
    float throwMultiplier;

    [SerializeField]
    Animator anim;

    bool stopDecay = false;

    //		anim = GetComponent<Animator>();
    //		anim.speed = 0f;
    //      anim.Play("YOUR_ANIMATION_NAME_HERE",0,YOUR_TIME_INDEX_HERE);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (throwMultiplier > 0 && !stopDecay)
        {
            throwMultiplier -= Time.deltaTime;
        }
        anim.Play("Throw", 0, Mathf.Clamp(throwMultiplier, 0, 0.99f));
    }
    public void ThrowMultiplier(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            throwMultiplier += context.ReadValue<float>() / 10000;
            throwMultiplier = Mathf.Clamp(throwMultiplier, 0, 1);

            stopDecay = true;    
        }
        if (context.canceled)
        {
            //stopDecay = false;
        }
    }
}
