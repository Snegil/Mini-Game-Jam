using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    float enemyHP;

    public void TakeDamage(float damageAmount)
    {
        enemyHP -= damageAmount;

        if (enemyHP <= 0)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            //GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0, 2), 2, Random.Range(0, 2)) * 2000);   
            gameObject.tag = "Untagged";

            StartCoroutine(DestroyObject());       
        }
    }
    IEnumerator DestroyObject() 
    {   
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
