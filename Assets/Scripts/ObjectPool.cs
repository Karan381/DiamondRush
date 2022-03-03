using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] int poolSize = 10;
    [SerializeField] float waitTime;// Start is called before the first frame update

    GameObject[] objectPool;

    private void Awake()
    {
        populatePool();
    }

    void Start()
    {
        StartCoroutine(DeployEnemy());
    }

    private void populatePool()
    {
        objectPool = new GameObject[poolSize];

        for(int i =0;i<objectPool.Length;i++)
        {
            objectPool[i]= Instantiate(Enemy, transform);
            objectPool[i].SetActive(false);
        }
    }

    private void EnableObjectinPool()
    {
        for (int i = 0; i < objectPool.Length; i++)
        { 
           if(objectPool[i].activeInHierarchy == false)
            {
                objectPool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator DeployEnemy()
    {
        while (true)
        {
            EnableObjectinPool();
            yield return new WaitForSeconds(waitTime);
        }
    }

}
