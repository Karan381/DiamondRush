using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetLocator : MonoBehaviour
{
    [SerializeField] float towerRange = 15f;
    ParticleSystem weaponParticles;
    [SerializeField] Transform weapon;
    Transform target;
    

    // Update is called once per frame
    void Update()
    {
        findClosestTarget();
        aimWeapon();
    }

    private void findClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
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

    private void aimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        if (targetDistance < towerRange)
        {
            weapon.LookAt(target);
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        weaponParticles=GetComponentInChildren<ParticleSystem>();
        var emmissionMoudle = weaponParticles.emission;
        emmissionMoudle.enabled = isActive;
    }
}
