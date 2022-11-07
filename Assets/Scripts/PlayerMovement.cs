using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private EntityStats stats;
    private Animator animator;    

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Rigidbody2D>(out rb);
        TryGetComponent<EntityStats>(out stats);
        TryGetComponent<Animator>(out animator);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 calc = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.velocity = calc * stats.Movespeed;
        AnimatePlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // get enemy stats
            collision.gameObject.TryGetComponent<EnemyStats>(out EnemyStats enemyStats);
            // if raging -> other behaviour on enemy hit (takes damage if in rage mode when hitting enemies)
            //Debug.Log("Enemy hit");

            if(GameManager.IsRaging)
            {
                // enemy does damage to player
                stats.TakeDamage(enemyStats.ContactDamage);
                // player kills enemy
                enemyStats.InstaKill();
            }
            else
            {
                enemyStats.InstaKill();
            }


        }

        // not affected by rage mode
        if (collision.gameObject.tag == "Pickup")
        {
            Debug.Log("Pickup collected");
            Destroy(collision.gameObject);

            // pickup logic with weapons
        }
    }

    void AnimatePlayer()
    {
        if (rb.velocity.magnitude > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

    }
}
