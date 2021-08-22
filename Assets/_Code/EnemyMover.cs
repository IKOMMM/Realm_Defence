using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyCoordinator))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WaypointHandler> path = new List<WaypointHandler>();
    [SerializeField] [Range(0f,5f)]float enemySpeed = 1f;

    EnemyCoordinator enemy;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        enemy = GetComponent<EnemyCoordinator>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            WaypointHandler waypoint = child.GetComponent<WaypointHandler>();

            if(waypoint != null)
            {
                path.Add(waypoint);
            }            
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPaht()
    {
        enemy.StealPoint();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach(WaypointHandler waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * enemySpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }            
        }

        FinishPaht();
    }
}
