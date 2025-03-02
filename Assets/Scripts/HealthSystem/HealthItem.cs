using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionPickUpScript : MonoBehaviour
{
    public PlayerHealthScript playerHealth;

    public int healPoints = 1;

    private bool isUsed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isUsed && collision.CompareTag("Player") && playerHealth.currentHealth < playerHealth.maxHealth)
        {
            isUsed = true;
            Debug.Log("Зелье использовано");    
            
            playerHealth.Heal(healPoints);
            Destroy(gameObject);
        }
    }
}
