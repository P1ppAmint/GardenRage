using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //TODO remove later
    [SerializeField]
    private float range;

    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float attackspeed;

    [SerializeField]
    private GameObject target;

    private bool isShooting;

    void Start()
    {
        if (attackPoint == null)
        {
            Debug.Log($"attackPoint is Null on {this.name}");
        }


    }

    void Update()
    {
        //TODO move target search to a coroutine for better performance
        target = FindClosestTargetInRange();
        if (target == null)
        {
            isShooting = false;
            StopCoroutine(Shoot());
        }
        else
        {
            if (isShooting == false)
            {
                isShooting = true;
                StartCoroutine(Shoot());                
            }            

        }     

    }



    IEnumerator Shoot()
    {
        while(isShooting == true)
        {
            Vector2 aimDirection = (target.transform.position - gameObject.transform.position).normalized;

            GameObject projectile = Instantiate(projectilePrefab, attackPoint.transform.position, Quaternion.identity);
            ProjectileManager projectileManager;
            projectile.TryGetComponent<ProjectileManager>(out projectileManager);

            projectileManager.InitializeProjectile(aimDirection);

            yield return new WaitForSeconds(1.0f/attackspeed);

        }
    }


    private GameObject FindClosestTargetInRange()
    {
        GameObject attackingEntity = gameObject;
        GameObject closestEnemy = null;
        float closestDistance = range;

        foreach  (GameObject enemy in GameManager.EnemyList)
        {
            float d = Vector2.Distance(enemy.transform.position, attackingEntity.transform.position);

            if (d <= closestDistance)
            {
                closestDistance = d;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
