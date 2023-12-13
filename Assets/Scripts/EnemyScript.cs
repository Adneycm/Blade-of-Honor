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

    private float distanceToPlayer;
    private float timer = 0f;
    [SerializeField] private float enemyAttackRate = 2f;
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float minimumAttackDistance = 4f;
    [SerializeField] private float minimumFollowDistance = 12;
    [SerializeField] private float enemyHorizontalDrag = 1;
    private enum enemyStateEnum { idle, run, attack, takehit }

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyBoxCollider = GetComponent<BoxCollider2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        enemyAnimation = GetComponent<Animator>();
        healthScript = GetComponent<HealthScript>();
    }

    void Update()
    {
        if (healthScript.checkHealth())
        {
            distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            FollowPlayer();
            EnemyAnimation();
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

        
        // Check if the enemy is running (backwards or front) or stopped based on it's horizontal velocity
        if (transform.position.x > player.transform.position.x && Mathf.Abs(distanceToPlayer) < minimumFollowDistance)
        {
            enemyState = enemyStateEnum.run;
            enemySprite.flipX = false;
        }
        else if (transform.position.x < player.transform.position.x && Mathf.Abs(distanceToPlayer) < minimumFollowDistance)
        {
            enemyState = enemyStateEnum.run;
            enemySprite.flipX = true;
        }
        else
        {
            enemyState = enemyStateEnum.idle;
        }

        // Check if the enemy made an attack by checking if it is closer enough to the player
        if (distanceToPlayer <= minimumAttackDistance && Time.time >= timer)
        {
            enemyState = enemyStateEnum.attack;
            timer = Time.time + 1f / enemyAttackRate;
        }

        // Set the state of the player to the animator
        enemyAnimation.SetInteger("enemyState", (int)enemyState);
    }
}
