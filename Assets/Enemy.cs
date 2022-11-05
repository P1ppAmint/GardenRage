using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public GameObject target;
    public bool isRaging;
    
    private Rigidbody2D myBody;
    private Vector2 direction;

    Transform targetTransform;


    void Start()
    {
        isRaging = CheckRageStatus();
        myBody = GetComponent<Rigidbody2D>();
        GetTargetTransform();
    }

    void FixedUpdate()
    {
        EnemyMove();
    }
    
    void EnemyMove()
    {
        direction = target.transform.position - myBody.transform.position;
        direction = direction.normalized;
        myBody.velocity = new Vector2(speed * direction.x, speed * direction.y);
    }

    bool CheckRageStatus()
    {
        //GetRageStatus from rageHandler
        return true;
    }

    void GetTargetTransform()
    {
        if(isRaging == false)
        {
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