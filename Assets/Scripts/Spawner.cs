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
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    //public GameObject[] listEnemy;

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
        GameObject enemyObj1 = Instantiate(enemy1, posSpawnLeft, transform.rotation) as GameObject;
        enemyObj1.GetComponent<Enemy3>().SetVellocity(true);
        
    }

    void SpawnRight()
    {
        GameObject enemyObj1 = Instantiate(enemy1, posSpawnRight, transform.rotation) as GameObject;
        enemyObj1.GetComponent<Enemy3>().SetVellocity(false);

    }
}
