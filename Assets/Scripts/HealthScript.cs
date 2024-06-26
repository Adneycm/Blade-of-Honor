using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Animator myAnimation;
    private BoxCollider2D myBoxCollider;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private int maxHealth = 100;
    private bool isAlive = true;
    private int currentHealth;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        currentHealth = maxHealth;
    }

    public void TakeHit(int damage)
    {
        if (isAlive)
        {
            // Subtract the damage from the current health of the caracter
            currentHealth = currentHealth - damage;

            // Play hit animation of the caracter
            myAnimation.SetTrigger("Hit");
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
       
        myRigidbody.bodyType = RigidbodyType2D.Static;
        myBoxCollider.enabled = false;
        myAnimation.SetTrigger("Death");
        isAlive = false;

        LordKuroshiScript lordKuroshiScript = gameObject.GetComponent<LordKuroshiScript>();
        if (lordKuroshiScript != null)
        {
            lordKuroshiScript.DestroyRightWall();
            audioManager.PlaySound(audioManager.lordKuroshiDie);  
        }
    }

    public bool checkHealth()
    {
        return isAlive;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(myBoxCollider.bounds.center, myBoxCollider.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }

    public void Heal(int heal)
    {
        currentHealth = currentHealth + heal;
        if (currentHealth >= 100)
        {
            currentHealth = 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Dead End"))
        {
            Die();
        }
    }
}
