using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealthScript : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 3;

    public SpriteRenderer playerSprt;
    public PlayerMovement playerMv;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            playerSprt.enabled = false;
            playerMv.enabled = false;
        }
    }

    public void Heal(int healAmount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healAmount;
            Debug.Log("Здоровье увеличено: " + currentHealth);
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}
