using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    public int currentHealth;
    public Slider healthSlider;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
