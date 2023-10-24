using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner spawner;
    Waves waves;
    List<Transform> waypoints;
    int waypointIndex = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        spawner = FindAnyObjectByType<EnemySpawner>();
    }
    void Start()
    {
        waves = spawner.getCurrentWave();
        waypoints = waves.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }
    public void FollowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition= waypoints[waypointIndex].position;
            float delta = waves.getMoveSpeed()*Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
