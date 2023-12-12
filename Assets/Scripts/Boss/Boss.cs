using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Movement")]
    public bool isFlipped = false;
    public Transform player;

    [Header("Health")]
    public Animator animator;
    public int maxHealth = 500;
    public int currentHealth;
    public SpriteRenderer spriteRenderer;
    public bool isInvulnerable = false;
    public bool isDead = false;
    private bool phase2Entered = false;

    // UI object to display winning text.
    public GameObject winTextObject;

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable) return;

        currentHealth -= damage;
        Debug.Log("Boss is at " + currentHealth + "HP");

        if (currentHealth <= 250 && !phase2Entered) 
        {
            EnterPhase2();
            phase2Entered = true;
        }

        if (currentHealth <= 0)
        {
            Death();
        }              
    }

    void EnterPhase2()
    {
        Debug.Log("Boss is enraged");
        animator.SetBool("isEnraged", true);        
    }

    void Death()
    {
        Debug.Log("Boss has died");
        animator.SetBool("isDead", true);
        Destroy(gameObject);
        Time.timeScale = 0f;
        winTextObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator.enabled = false;
        // Initially set the win text to be inactive.
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
