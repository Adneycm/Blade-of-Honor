using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    private BoxCollider2D enemyBoxCollider;
    private SpriteRenderer enemySprite;
    private Animator enemyAnimation;
    private HealthScript healthScript;

    [SerializeField] private GameObject player;
    private PlayerScript playerScript;
    private float distanceToPlayer;

    // Layers
    [SerializeField] private LayerMask playerLayer;
    // Enemy Attack
    private float enemyAttackTimer = 0f;
    private float enemyAttackPointX;
    [SerializeField] private Transform enemyAttackPoint;
    [SerializeField] private int enemyDamageAttack = 20;
    [SerializeField] private float enemyAttackRange = 0.5f;
    [SerializeField] private float enemyAttackRate = 2f;
    [SerializeField] private float minimumAttackDistance = 4f;
    // Enemy Movement
    [SerializeField] private bool enemySpriteFlipped = false;
    [SerializeField] private float minimumFollowDistance = 12;
    [SerializeField] private float enemyHorizontalDrag = 1;
    // Knock Back
    public float enemyKnockBackForce = 4;
    public float enemyKnockBackCounter = 0;
    public float enemyKnockBackTotalTime = 0.2f;
    public bool enemyKnockBackDirection; // true -> right | false -> left
    private enum enemyStateEnum { idle, run, attack }
    AudioManager audioManager;
    private float timer;


    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyBoxCollider = GetComponent<BoxCollider2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        enemyAnimation = GetComponent<Animator>();
        healthScript = GetComponent<HealthScript>();
        enemyAttackPointX = Mathf.Abs(enemyAttackPoint.position.x - transform.position.x);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (healthScript.checkHealth())
        {
            distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            EnemyMovement();
            EnemyAnimation();
        }
    }

    private void EnemyMovement()
    {
        if (enemyKnockBackCounter < 0)
        {
            if (!enemyAnimation.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                FollowPlayer();
            }
        }
        else
        {
            if (enemyKnockBackDirection == true)
            {
                enemyRigidbody.velocity = new Vector2(-enemyKnockBackForce, enemyKnockBackForce);
            }
            if (enemyKnockBackDirection == false)
            {
                enemyRigidbody.velocity = new Vector2(enemyKnockBackForce, enemyKnockBackForce);
            }
            enemyKnockBackCounter -= Time.deltaTime;
        }
    }

    private void EnemyAttack()
    {
        Collider2D[] hittedPlayer = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayer);
        foreach (Collider2D player in hittedPlayer)
        {
            playerScript = player.GetComponent<PlayerScript>();
            playerScript.playerKnockBackCounter = playerScript.playerKnockBackTotalTime;
            if (player.transform.position.x <= transform.position.x)
            {
                playerScript.playerKnockBackDirection = true;
            }
            if (player.transform.position.x >= transform.position.x)
            {
                playerScript.playerKnockBackDirection = false;
            }
            // Check if the enemy is LordKuroshi and if so update it's health bar
            LordKuroshiScript lordKuroshiScript = gameObject.GetComponent<LordKuroshiScript>();
            if (lordKuroshiScript != null)
            {
                audioManager.PlaySound(audioManager.lordKuroshiAttack);
            }

            audioManager.PlaySound(audioManager.damageSound);
            player.GetComponent<HealthScript>().TakeHit(enemyDamageAttack);
            player.GetComponent<HealthBarScript>().TakeHit(enemyDamageAttack);

        }
    }

    private void FollowPlayer()
    {
        // Check if player is in reach to follow and if the enemy is alive
        if (Mathf.Abs(distanceToPlayer) < minimumFollowDistance)
        {
            transform.position = Vector2.MoveTowards(
            this.transform.position, player.transform.position, distanceToPlayer * Time.deltaTime / enemyHorizontalDrag);
        }
    }

    private void EnemyAnimation()
    {
        enemyStateEnum enemyState;

        // Check if the enemy made an attack by checking if it is closer enough to the player
        if (distanceToPlayer <= minimumAttackDistance && Time.time >= enemyAttackTimer)
        {
            enemyState = enemyStateEnum.attack;
            enemyAttackTimer = Time.time + 1f / enemyAttackRate;
            EnemyAttack();
        }

        // Check if the enemy is running (backwards or front) or stopped based on it's horizontal velocity
        else if (transform.position.x > player.transform.position.x && Mathf.Abs(distanceToPlayer) < minimumFollowDistance)
        {
            enemyState = enemyStateEnum.run;
            if (enemySpriteFlipped)
            {
                enemySprite.flipX = true;
            } else { enemySprite.flipX = false; }
            enemyAttackPoint.position = new Vector2(transform.position.x - enemyAttackPointX, transform.position.y);
        }
        else if (transform.position.x < player.transform.position.x && Mathf.Abs(distanceToPlayer) < minimumFollowDistance)
        {
            enemyState = enemyStateEnum.run;
            if (enemySpriteFlipped)
            {
                enemySprite.flipX = false;
            }
            else { enemySprite.flipX = true; }
            enemyAttackPoint.position = new Vector2(transform.position.x + enemyAttackPointX, transform.position.y);
        }
        else
        {
            enemyState = enemyStateEnum.idle;
        }


        if (enemyState == enemyStateEnum.attack && timer > 1)
        {
            timer = 0;
            // Checking if the enemy is LordKuroshi to perform attack sound
            LordKuroshiScript lordKuroshiScript = gameObject.GetComponent<LordKuroshiScript>();
            if (lordKuroshiScript != null)
            {
                audioManager.PlaySound(audioManager.lordKuroshiAttack);
            }
        }

        // Set the state of the player to the animator
        enemyAnimation.SetInteger("enemyState", (int)enemyState);
    }

    private void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(enemyAttackPoint.position, enemyAttackRange);
    }

    public bool checkHealth()
    {
        return healthScript.checkHealth();
    }
}
