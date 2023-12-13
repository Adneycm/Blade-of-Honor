using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetector : MonoBehaviour
{
    private Rigidbody2D caracterRigidbody;
    private Animator caracterAnimation;

    /*
     This tag is set in the unity software. For the player the attackingTag must be the "Enemy",
     and for the enemies, the tag must be "Player".
     */
    [SerializeField] private string attackingTag; 

    private void Start()
    {
        caracterRigidbody = GetComponent<Rigidbody2D>();
        caracterAnimation = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(attackingTag))
        {
            TakeHit();
        }
    }

    private void TakeHit()
    {
        
    }

    private void Die()
    {
        caracterRigidbody.bodyType = RigidbodyType2D.Static;
        caracterAnimation.SetTrigger("Death");
    }

}
