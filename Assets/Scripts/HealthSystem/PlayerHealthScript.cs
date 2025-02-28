using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
