using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerBoxCollider;
    private SpriteRenderer playerSprite;
    private Animator playerAnimation;

    [SerializeField] private LayerMask ground;
    [SerializeField] private float playerVerticalStrength;
    [SerializeField] private float playerHorizontalStrength;
    [SerializeField] private float playerHorizontalVelocity = 0f;
    private bool playerIsAlive = true;
    private enum playerStateEnum { idle, run, jump, fall, attack1, attack2 }


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHorizontalVelocity = Input.GetAxisRaw("Horizontal");
        playerRigidbody.velocity = new Vector2(playerHorizontalVelocity * playerHorizontalStrength, playerRigidbody.velocity.y);


        if (Input.GetButtonDown("Jump") && playerIsAlive && IsGrounded())
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, playerVerticalStrength);
        }

        PlayerAnimation();

    }

    private void PlayerAnimation()
    {
        playerStateEnum playerState;

        // Check if the player is running (backwards or front) or stopped based on it's horizontal velocity
        if (playerHorizontalVelocity > 0f)
        {
            playerState = playerStateEnum.run;
            playerSprite.flipX = false;
        }
        else if (playerHorizontalVelocity < 0f)
        {
            playerState = playerStateEnum.run;
            playerSprite.flipX = true;
        }
        else
        {
            playerState = playerStateEnum.idle;
        }

        // Check if the player made an attack by checking the keys
        if (Input.GetKeyDown("mouse 0"))
        {
            playerState = playerStateEnum.attack1;
        } 
        else if (Input.GetKeyDown("mouse 1")) 
        {
            playerState = playerStateEnum.attack2;
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

        // Set the state of the player to the animator
        playerAnimation.SetInteger("playerState", (int)playerState);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size, 0f, Vector2.down, .1f, ground);
    }
}