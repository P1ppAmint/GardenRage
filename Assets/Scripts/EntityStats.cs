using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EntityStats : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private float movespeed;
    [SerializeField]
    private float range;

    public int Health { get => health; set => health = value; }
    public float Movespeed { get => movespeed; set => movespeed = value; }
    public float Range { get => range; set => range = value; }


    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)    OnDeath();
    }

    public void InstaKill()
    {
        OnDeath();
    }

    abstract protected void OnDeath();
    
}
