using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] ParticleSystem bulletParticles;
    [SerializeField] Transform weapon;    
    [SerializeField] float towersRange = 18f;    
    Transform target;          
        
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        EnemyCoordinator[] enemies = FindObjectsOfType<EnemyCoordinator>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(EnemyCoordinator enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }            
        }

        target = closestTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);

        if(targetDistance < towersRange)
        {
            Attac(true);
        }
        else
        {
            Attac(false);
        }
    }

    void Attac(bool isActive)
    {
        var emissionModule = bulletParticles.emission;
        emissionModule.enabled = isActive;

    }
}
