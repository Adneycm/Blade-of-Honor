using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootScript : MonoBehaviour
{

    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform arrowPosition;
    private EnemyScript enemyScript;

    private float timer;


    void Start()
    {
        enemyScript = GetComponent<EnemyScript>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    private void shoot()
    {
        if (enemyScript.checkHealth())
        {
            Instantiate(arrow, arrowPosition.position, Quaternion.identity);
        }
            
    }
}
