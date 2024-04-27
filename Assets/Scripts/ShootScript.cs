using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform arrowPosition;
    [SerializeField] private float minimumShootDistance;
    private float distanceToPlayer;
    private EnemyScript enemyScript;

    private float timer;


    void Start()
    {
        enemyScript = GetComponent<EnemyScript>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    private void shoot()
    {
        if (enemyScript.checkHealth() && Mathf.Abs(distanceToPlayer) < minimumShootDistance)
        {
            Instantiate(arrow, arrowPosition.position, Quaternion.identity);
        }
            
    }
}
