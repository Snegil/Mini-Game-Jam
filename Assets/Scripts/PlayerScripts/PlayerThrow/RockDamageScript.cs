using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockDamageScript : MonoBehaviour
{
    float throwMultiplier;

    bool hitEnemy = false;

    [SerializeField]
    LayerMask layer;

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(throwMultiplier);
        if (hitEnemy)
        {
            return;
        }
        if (other.collider.CompareTag("Enemy"))
        {
            other.collider.GetComponent<EnemyHP>().TakeDamage(throwMultiplier);
        }
        gameObject.layer = layer;
        hitEnemy = true;
    }
    public void AssignThrowMultiplier(float val)
    {
        throwMultiplier = val;
    }
}
