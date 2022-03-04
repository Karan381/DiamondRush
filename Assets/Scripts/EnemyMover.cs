using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)]float speed = 1f;
    [SerializeField] float rotationSpeed = 1f;
   
    Enemy enemy;
    // Start is called before the first frame update

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if(waypoint != null)
            {
                path.Add(waypoint);
            }
           // path.Add(child.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        gameObject.SetActive(false);
        enemy.StealGold();
    }
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            Quaternion startRotation = transform.rotation;//new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
            Quaternion endRotation = Quaternion.LookRotation(endPos - startPos);
            float travelPercent = 0f;
            while (travelPercent < 1f)
            {
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                transform.rotation = Quaternion.Lerp(startRotation, endRotation, Mathf.Clamp(travelPercent * rotationSpeed, 0, 1));
                travelPercent += Time.deltaTime * speed;
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

}
