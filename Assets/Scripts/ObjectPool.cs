using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] float waitTime;// Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeployEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeployEnemy()
    {
        while (true)
        {
            Instantiate(Enemy, transform);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
