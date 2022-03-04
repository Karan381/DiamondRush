using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int MaxHitPoints = 5;
    [Tooltip("Adds to max hit points on enemy ded")]
    [SerializeField] int diicultyRamp = 1;
    int currenthitpoints = 0;
    Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        currenthitpoints = MaxHitPoints;
    }

    // Update is called once per frame
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currenthitpoints--;
        if (currenthitpoints <= 0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
            MaxHitPoints += diicultyRamp;
        }
    }
}
