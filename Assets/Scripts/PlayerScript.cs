using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerBoxCollider;
    private SpriteRenderer playerSprite;
    private Animator playerAnimation;
    private HealthScript healthScript;
    private HealthBarScript healthBarScript;
    private ItemCollector itemCollector;
    private EnemyScript enemyScript;
    private GameOver gameOverScript;

    // Layers
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask enemyLayer;
    // Player Attack
    private float playerAttackPointX;
    [SerializeField] private Transform playerAttackPoint;
    [SerializeField] private int playerDamageAttack1 = 20;
    [SerializeField] private int playerDamageAttack2 = 30;
    [SerializeField] private float playerAttackRange = 0.5f;
    // Player Movement
    [SerializeField] private float playerVerticalStrength = 14;
    [SerializeField] private float playerHorizontalStrength = 10;
    [SerializeField] private float playerHorizontalVelocity = 0f;
    // Knock Back
    public float playerKnockBackForce = 4;
    public float playerKnockBackCounter = 0;
    public float playerKnockBackTotalTime = 0.2f;
    public bool playerKnockBackDirection; // true -> right | false -> left
    private enum playerStateEnum { idle, run, jump, fall, attack1, attack2 }

    AudioManager audioManager;
    private string currentSceneName;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<Animator>();
        healthScript = GetComponent<HealthScript>();
        healthBarScript = GetComponent<HealthBarScript>();
        gameOverScript = GetComponent<GameOver>();
        itemCollector = GetComponent<ItemCollector>();
    playerAttackPointX = Mathf.Abs(playerAttackPoint.position.x - transform.position.x);
    }

    void Update()
    {
        if (healthScript.checkHealth())
        {
            PlayerMovement();
            PlayerAnimation();
            PlayerHeal();
        } else
        {
            gameOverScript.ActivateGameOver();
        }
    }

    private void PlayerMovement()
    {
        if (playerKnockBackCounter < 0)
        {
            if (!playerAnimation.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                playerHorizontalVelocity = Input.GetAxisRaw("Horizontal");
                playerRigidbody.velocity = new Vector2(playerHorizontalVelocity * playerHorizontalStrength, playerRigidbody.velocity.y);
            } else
            {
                playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
            }
        }
        else
        {
            if (playerKnockBackDirection == true)
            {
                playerRigidbody.velocity = new Vector2(-playerKnockBackForce, playerKnockBackForce);
            }
            if (playerKnockBackDirection == false)
            {
                playerRigidbody.velocity = new Vector2(playerKnockBackForce, playerKnockBackForce);
            }
            playerKnockBackCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, playerVerticalStrength);
            audioManager.PlaySound(audioManager.jumpSound);
        }
    }

    private void PlayerAttack(int damage)
    {
        Collider2D[] hittedEnemies = Physics2D.OverlapCircleAll(playerAttackPoint.position, playerAttackRange, enemyLayer);
        foreach(Collider2D enemy in hittedEnemies)
        {
            enemy.GetComponent<HealthScript>().TakeHit(damage);
            enemyScript = enemy.GetComponent<EnemyScript>();
            enemyScript.enemyKnockBackCounter = enemyScript.enemyKnockBackTotalTime;

            // Check if the enemy is LordKuroshi and if so update it's health bar
            HealthBarScript healthBarScript = enemy.GetComponent<HealthBarScript>();
            if (healthBarScript != null)
            {
                healthBarScript.TakeHit(damage);
            }

            if (enemy.transform.position.x <= transform.position.x)
            {
                enemyScript.enemyKnockBackDirection = true;
            }
            if (enemy.transform.position.x >= transform.position.x)
            {
                enemyScript.enemyKnockBackDirection = false;
            }
            //enemy.GetComponent<HealthScript>().TakeHit(damage);
        }
    }

    private void PlayerAnimation()
    {
        playerStateEnum playerState;

        // Check if the player is running (backwards or front) or stopped based on it's horizontal velocity
        if (playerHorizontalVelocity > 0f)
        {
            playerState = playerStateEnum.run;
            playerSprite.flipX = false;
            playerAttackPoint.position = new Vector2(transform.position.x + playerAttackPointX, transform.position.y);
        }
        else if (playerHorizontalVelocity < 0f)
        {
            playerState = playerStateEnum.run;
            playerSprite.flipX = true;
            playerAttackPoint.position = new Vector2(transform.position.x - playerAttackPointX, transform.position.y);
        }
        else
        {
            playerState = playerStateEnum.idle;
        }

        // Check if the player is jumping or falling based on it's vertical velocity
        if (playerRigidbody.velocity.y > .1f)
        {
            playerState = playerStateEnum.jump;
        }
        else if (playerRigidbody.velocity.y < -.1f)
        {
            playerState = playerStateEnum.fall;
        }


        // Check if the player made an attack by checking the keys
        else if (Input.GetKeyDown("mouse 0"))
        {
            playerState = playerStateEnum.attack1;
            PlayerAttack(playerDamageAttack1);
            audioManager.PlaySound(audioManager.atackSound1);
        }
        else if (Input.GetKeyDown("mouse 1"))
        {
            playerState = playerStateEnum.attack2;
            PlayerAttack(playerDamageAttack2);
            audioManager.PlaySound(audioManager.atackSound2);
        }

        // Set the state of the player to the animator
        playerAnimation.SetInteger("playerState", (int)playerState);
    }

    private void OnDrawGizmosSelected()
    {
        if (playerAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(playerAttackPoint.position, playerAttackRange);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }

    private void PlayerHeal()
    {
        if (Input.GetKeyDown("c"))
        {
            int heal = itemCollector.getPotionHeal();
            healthScript.Heal(heal);
            healthBarScript.Heal(heal);
            audioManager.PlaySound(audioManager.potionDrink);
        }
    }
}
