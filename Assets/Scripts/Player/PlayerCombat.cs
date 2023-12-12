using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public LayerMask bossLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 50;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                BasicAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void BasicAttack()
    {
        // play attack animation
        animator.SetTrigger("Attack");

        // detect enemy in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Collider2D[] hitBoss = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bossLayers);

        // damage 
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("enemy hit: " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        foreach(Collider2D boss in hitBoss)
        {
            Debug.Log("boss hit: " + boss.name);
            boss.GetComponent<Boss>().TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


