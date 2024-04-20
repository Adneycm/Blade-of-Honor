using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootScript : MonoBehaviour
{

    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform arrowPosition;

    private float timer;
    // Update is called once per frame
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
        Instantiate(arrow, arrowPosition.position, Quaternion.identity);
    }
}
