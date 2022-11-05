using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private EntityStats stats;

    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float attackspeed;


    private GameObject target;

    private bool isShooting;

    void Start()
    {
        if (attackPoint == null)
        {
            Debug.Log($"attackPoint is Null on {this.name}");
        }

        stats = transform.GetComponentsInParent<EntityStats>()[0];
        if (stats == null) Debug.Log($"Stats script not found in {name}");
    }

    void Update()
    {
        //TODO move target search to a coroutine for better performance
        target = FindClosestTargetInRange();
        Debug.Log(target);

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
        //TODO change attacking entity to player
        GameObject attackingEntity = gameObject;
        GameObject closestEnemy = null;
        float closestDistance = stats.range;

        foreach(GameObject enemy in GameManager.EnemyList)
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
        Gizmos.DrawWireSphere(transform.position, stats.range);       
    }
}
