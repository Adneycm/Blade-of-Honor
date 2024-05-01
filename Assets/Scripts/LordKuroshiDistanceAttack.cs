using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordKuroshiDistanceAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<HealthScript>().TakeHit(damage);
            collision.GetComponent<HealthBarScript>().TakeHit(damage);
        }
    }
}
