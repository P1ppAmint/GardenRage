using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public GameManager gameManager;
    // Health
    // MovementSpeed
    // Range
    public int health;
    public float movespeed;
    public float range;


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (gameObject.tag == "Player")
        {
            HealthbarManager.SetHealth(health);
        }


        if (health <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                gameManager.RemoveEnemyFromList(gameObject);
            }

            Destroy(gameObject);
        }
    }
}
