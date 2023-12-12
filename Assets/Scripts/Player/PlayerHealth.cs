using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public Animator animator;
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;    

    [Header("Iframes")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;
    private bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;
        
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0) 
        {
            Death();
        }

        StartCoroutine(Invulnerability());
    }

    void Death()
    {
        Debug.Log("Player has died");
        
        animator.SetBool("isDead", true);
      
        //Destroy(gameObject);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 10, true);
        Physics2D.IgnoreLayerCollision(6, 9, true);

        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
        }

        Physics2D.IgnoreLayerCollision(6, 10, false);
        Physics2D.IgnoreLayerCollision(6, 9, false);
    }
}
