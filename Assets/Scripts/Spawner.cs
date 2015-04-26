using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public float spawnTime;
    public float spawnDelay;

    public Vector2 posSpawnLeft;
    public Vector2 posSpawnRight;

    //public Enemy[] enemies;
    //public int index;
    public GameObject[] enemyPrefab;

    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }
    void Spawn()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
        {
            SpawnLeft();
        }
        else
        {
            SpawnRight();
        }
    }

    void SpawnLeft()
    {
        // Random loại enemy
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        GameObject enemyObj = Instantiate(enemyPrefab[enemyIndex], posSpawnLeft, Quaternion.identity) as GameObject;
        enemyObj.GetComponent<Enemy>().SetVellocity(true);
        enemyObj.GetComponent<Enemy2>().SetVellocity(true);
    }

    void SpawnRight()
    {
        // Random loại enemy
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        GameObject enemyObj = Instantiate(enemyPrefab[enemyIndex], posSpawnRight, Quaternion.identity) as GameObject;
        enemyObj.GetComponent<Enemy>().SetVellocity(false);
        enemyObj.GetComponent<Enemy2>().SetVellocity(false);
    }
}
