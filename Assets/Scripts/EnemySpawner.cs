using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Waves> wavesComfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    Waves currentWave;
    bool isLooping=true;
    void Start()
    {
        StartCoroutine( SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (var wave in wavesComfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.getEnemyCount(); i++)
                {
                    Instantiate(currentWave.getEnemyPrefab(0), currentWave.getStartedWaypoint().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpwnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping);
    }
    public Waves getCurrentWave()
    {
        return currentWave;
    }
}
