using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{

    // Health
    // MovementSpeed
    // Range
    public int health;
    public float movespeed;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        health = 25;
        movespeed = 2;
        range = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
