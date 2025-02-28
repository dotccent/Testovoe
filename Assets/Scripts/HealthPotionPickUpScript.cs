using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionPickUpScript : MonoBehaviour
{
    public int healthPoint = 1;
    public PlayerHealthScript characterHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Health pick up")
        {
            characterHealth.currentHealth += healthPoint;
            Destroy(gameObject);
        }
    }
}
