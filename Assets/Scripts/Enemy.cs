using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public PlayerHealth playerHealth;
    
    public int maxHealth = 100;
    private int currentHealth;
    public int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy is at " + currentHealth + "hp");

        // Play hurt animation
        //animator.SetTrigger("Hurt");

        // Call death function upon <=0 health
        if (currentHealth <= 0) 
        {
            Death();
        }

    }

    void Death()
    {
        Debug.Log("Enemy has died!");

        // Play death animation
        //animator.SetBool("IsDead", true);

        // disable enemy
        //GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
