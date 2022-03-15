using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public int attackDamage = 1;
    private GameObject enemy;
    private EnemyHealth enemyHealth;

    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == enemy)
        {
            enemyHealth.TakeDamage(attackDamage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
