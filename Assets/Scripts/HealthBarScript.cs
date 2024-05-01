using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    [SerializeField] private Image healthBar;
    [SerializeField] private float health = 100f;    

    public void TakeHit(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100f;
    }

    public void Heal(int heal)
    {
        health += heal;
        health = Mathf.Clamp(health, 0, 100);
        healthBar.fillAmount = health / 100f;
    }
}
