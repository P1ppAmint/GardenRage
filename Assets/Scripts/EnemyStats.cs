using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : EntityStats
{
    [SerializeField]
    private int contactDamage;
    public int ContactDamage { get => contactDamage; set => contactDamage = value; }

    protected override void OnDeath()
    {
        GameManager.RemoveEnemyFromList(gameObject);
        Destroy(gameObject);        
    }
}
