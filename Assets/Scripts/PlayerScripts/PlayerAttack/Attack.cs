using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [Space, SerializeField]
    float attackCooldown;
    float setAttackCooldown;

    [Space, SerializeField, Header("Weapon stats")]
    List<GameObject> rockDestructionLevels = new();
    [SerializeField]
    int rockHealth = 9;    

    [Space, SerializeField]
    Animator anim;

    [SerializeField, Header("Layers that will be hit.")]
    LayerMask layerMask;

    [SerializeField]
    float distance;
    [SerializeField]
    Transform rock;

    

    // Start is called before the first frame update
    void Start()
    {
        setAttackCooldown = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;    
        }        
    }

    public void AttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PlayerAttack();
        }
    }

    public void PlayerAttack()
    {
        if (attackCooldown > 0)
        {
            return;
        }

        anim.SetTrigger("Attack");
        attackCooldown = setAttackCooldown;

        Physics.Raycast(Camera.main.gameObject.transform.position, Camera.main.gameObject.transform.forward * distance, out RaycastHit hit, 1, layerMask);
        
        if (hit.collider == null)
        {
            return;
        }

        if (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Wall"))
        {
            rockHealth--;
            
        }
    }
}
