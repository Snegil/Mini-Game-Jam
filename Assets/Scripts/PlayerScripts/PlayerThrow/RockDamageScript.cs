using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockDamageScript : MonoBehaviour
{
    float throwMultiplier;

    bool hitEnemy = false;

    void OnCollisionEnter(Collision other)
    {
        if (hitEnemy)
        {
            return;
        }
        if (other.collider.CompareTag("Enemy"))
        {
            other.collider.GetComponent<EnemyHP>().TakeDamage(throwMultiplier);
        }
        GetComponent<Collider>().enabled = false;
        hitEnemy = true;
    }
    public void AssignThrowMultiplier(float val)
    {
        throwMultiplier = val;
    }
}
