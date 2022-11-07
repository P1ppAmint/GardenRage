using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : EntityStats
{
    public new void TakeDamage(int damage)
    {
        Health -= damage;
        HealthbarManager.SetHealth(Health);
        if (Health <= 0)    OnDeath();
    }

    protected override void OnDeath()
    {
        throw new System.NotImplementedException();
    }
}
