using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    EntityStats stats;
    EntityStats enemyStats;
    [SerializeField]
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Rigidbody2D>(out rb);
        TryGetComponent<EntityStats>(out stats); 
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 calc = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.velocity = calc * stats.movespeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            // get enemy stats
            gameObject.TryGetComponent<EntityStats>(out enemyStats);
            // if raging -> other behaviour on enemy hit (takes damage if in rage mode when hitting enemies)
            Debug.Log("Enemy hit");

            if(gameManager.isRaging)
            {
                // enemy does damage to player
                stats.takeDamage(4);
                // player kills enemy
                
                enemyStats.takeDamage(999)
            }
            else
            {
                enemyStats.takeDamage(999);
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
}
