using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject target;

    
    private Rigidbody2D myBody;
    private Vector2 direction;

    private Transform targetTransform;

    private EntityStats stats;


    void Start()
    {
        stats = GetComponent<EntityStats>();
        if (stats == null) Debug.Log($"No entitystats found in {gameObject}");

        myBody = GetComponent<Rigidbody2D>();
        GetTargetTransform();

    }

    void FixedUpdate()
    {
        MoveEnemy();
    }
    
    void MoveEnemy()
    {
        direction = target.transform.position - myBody.transform.position;
        direction = direction.normalized;
        myBody.velocity = new Vector2(direction.x, direction.y)*stats.Movespeed;
    }


    void GetTargetTransform()
    {
        if(GameManager.IsRaging == false)
        {
            //Debug.Log(target == null);
            target = GameObject.FindWithTag("Plant");
            if (target != null)
            {
                targetTransform = target.transform;
            }
            else
            {
                Debug.Log("Target not specified in Inspector");
            }
        }
        else
        {
            target = GameObject.FindWithTag("Player");

            if (target != null)
            {
                targetTransform = target.transform;
            }
            else
            {
                Debug.Log("Target not specified in Inspector");
            }
        }

      
    }

}