using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config", fileName ="New wave Config")]
public class Waves : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPre;
    [SerializeField] Transform path;
    [SerializeField] float moveSpeed=5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public Transform getStartedWaypoint()
    {
        return path.GetChild(0);
    }
    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in path)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    public int getEnemyCount() { return enemyPre.Count; }

    public GameObject getEnemyPrefab(int index)
    {
        return enemyPre[index];
    }
    public float GetRandomSpwnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
