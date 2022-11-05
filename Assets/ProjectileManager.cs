using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField]
    private float projectileSpeed;

    private Vector2 movementDirection;

    private Rigidbody2D rb;


    void Start()
    {
        TryGetComponent<Rigidbody2D>(out rb);
    }

    public void InitializeProjectile(Vector2 direction)
    {
        movementDirection = direction;
    }

    public void FixedUpdate()
    {
        rb.velocity = movementDirection * projectileSpeed;
    }
}
