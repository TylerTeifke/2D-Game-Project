using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Combat : MonoBehaviour
{
    public PlayerHealth playerHealth;
    
    public int attackDamage = 20;
    public int enragedAttackDamage = 30;

    public Vector3 attackOffset;
    public float attackRange = 0.6f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colliderInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colliderInfo != null)
        {
            colliderInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    public void EnragedAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colliderInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colliderInfo != null)
        {
            colliderInfo.GetComponent<PlayerHealth>().TakeDamage(enragedAttackDamage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(attackDamage);
        }*/
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
