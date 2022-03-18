using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int startingHealth;
    public int currentHealth;
    [SerializeField] private Slider healthSlider;

    private bool playerWin;

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
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        gameObject.SetActive(false);
    }
}
