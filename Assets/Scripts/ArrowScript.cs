using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D arrowRigidBody;

    [SerializeField] private float arrowForce;
    [SerializeField] private int arrowDamageAttack = 20;
    private PlayerScript playerScript;

    private float timer;

    void Start()
    {
        arrowRigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        arrowRigidBody.velocity = new Vector2(direction.x, direction.y).normalized * arrowForce;

        float arrowRotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, arrowRotation + 180);

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10) { Destroy(gameObject); };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

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
            player.GetComponent<HealthScript>().TakeHit(arrowDamageAttack);
            player.GetComponent<HealthBarScript>().TakeHit(arrowDamageAttack);
        }
    }
}
