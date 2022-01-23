using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 respawnPoint;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FieldEnemy"))
        {
            TakeDamage(50);
        }

        if (other.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = other.transform.position;
        }

        if (currentHealth <= 5)

        {
            Respawn();
        }
    }

  
        void Respawn()
        {
            transform.position = respawnPoint;
            currentHealth = maxHealth;
        }
    

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    
    
}