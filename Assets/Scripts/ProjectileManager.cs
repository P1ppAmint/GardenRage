using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField]
    private float projectileSpeed;

    private int projectileDamage;

    private Vector2 movementDirection;

    private Rigidbody2D rb;


    void Start()
    {
        TryGetComponent<Rigidbody2D>(out rb);
    }

    public void InitializeProjectile(Vector2 direction, int damage)
    {
        movementDirection = direction;
        projectileDamage = damage;
    }

    public void FixedUpdate()
    {
        rb.velocity = movementDirection * projectileSpeed;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {            
        Collider2D projectileCollider = GetComponent<Collider2D>();
        GameObject collidedObject = collision.gameObject;       

        //Debug.Log("Collision detected");

        if (gameObject.tag == collidedObject.tag)
        {
            Physics2D.IgnoreCollision(projectileCollider, collision);            
        }
        else
        {
            EntityStats collidedObjectStats = collidedObject.GetComponent<EntityStats>();
            if (collidedObjectStats != null)
            {
                collidedObjectStats.TakeDamage(projectileDamage);
            }
            //Destroys Projectile after Collision
            Destroy(gameObject);
        }
    }
}
