using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    float playerHP;
    float playerMaxHP;

    [SerializeField]
    float hurtTimer;
    float setHurtTimer;

    [SerializeField]
    DeathScript deathScript;

    void Start()
    {
        setHurtTimer = hurtTimer;
        playerMaxHP = playerHP;
    }
    void Update()
    {
        hurtTimer -= Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            if (hurtTimer <= 0 && playerHP != 0)
            {
                playerHP--;

                //Debug.Log(playerHP);

                float division = playerHP / playerMaxHP;
                float summed = 1 - division;
                Debug.Log(summed);
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1 - playerHP / playerMaxHP);
                hurtTimer = setHurtTimer;  
            }            
        }
        if (playerHP == 0)
        {
            deathScript.DeclaredDead();
        }
    }
}
