using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    EntityStats status;


    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Rigidbody2D>(out rb);
        TryGetComponent<EntityStats>(out status); 
    }

    // Update is called once per frame
    void Update()
    {

        //// rb velocity + vector
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //rb.velocity = rb.velocity.normalized;
        //rb.velocity *= status.movespeed;


        Vector2 calc = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.velocity = calc * status.movespeed;



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // tag Enemy 
        // tag Pickup

        if (collision.gameObject.tag == "Enemy")
        {
            // if raging -> other behaviour on enemy hit (takes damage if in rage mode when hitting enemies)
            Debug.Log("Enemy hit");
            Destroy(collision.gameObject);
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
