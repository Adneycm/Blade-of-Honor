using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordKuroshiScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float distanceToAttackDistance;
    [SerializeField] private GameObject distanceAttack;
    [SerializeField] private GameObject rightWall;
    private Animator lordKuroshiAnimator;
    private HealthScript healthScript;
    private float distanceToPlayer;
    private float timer;

    void Start()
    {
        healthScript = GetComponent<HealthScript>();
        lordKuroshiAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (healthScript.checkHealth())
        {
            distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            DistanceAttack();
        }
    }

    private void DistanceAttack()
    {
        if (distanceToPlayer >= distanceToAttackDistance)
        {
            if (timer > 5)
            {
                timer = 0;
                lordKuroshiAnimator.SetTrigger("DistAttack");
                Instantiate(distanceAttack, player.transform.position, Quaternion.identity);
                //Destroy(distanceAttack, 6f);
            }

        }
    }

    public void DestroyRightWall()
    {
        Destroy(rightWall);
    }

}
