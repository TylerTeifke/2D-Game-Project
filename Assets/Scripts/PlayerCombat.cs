using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            BasicAttack();
        }
    }

    void BasicAttack()
    {
        // play attack animation
        animator.SetTrigger("Attack");

        // detect enemy in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // damage 
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("enemy hit: " + enemy.name);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


