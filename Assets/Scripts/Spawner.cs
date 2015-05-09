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
        //int enemyIndex = Random.Range(0, enemyPrefab.Length);
        //GameObject enemyObj1 = Instantiate(enemy1, posSpawnLeft, transform.rotation) as GameObject;
        //enemyObj1.GetComponent<Enemy>().SetVellocity(true);

        GameObject enemyObj2 = Instantiate(enemy2, posSpawnLeft, transform.rotation) as GameObject;
        enemyObj2.GetComponent<Enemy2>().SetVellocity(true);

        //GameObject enemyObj4 = Instantiate(enemy4, posSpawnLeft, transform.rotation) as GameObject;
        //enemyObj4.GetComponent<Enemy4>().SetVellocity(true);

        //GameObject enemyObj3 = Instantiate(enemy3, posSpawnLeft, transform.rotation) as GameObject;
       // enemyObj3.GetComponent<Enemy3>().SetVellocity(true);

    }

    void SpawnRight()
    {
        // Random loại enemy
        //int enemyIndex = Random.Range(0, enemyPrefab.Length);
        //GameObject enemyObj1 = Instantiate(enemy1, posSpawnRight, transform.rotation) as GameObject;
        //enemyObj1.GetComponent<Enemy>().SetVellocity(false);

        GameObject enemyObj2 = Instantiate(enemy2, posSpawnRight, transform.rotation) as GameObject;
        enemyObj2.GetComponent<Enemy2>().SetVellocity(false);

        //GameObject enemyObj4 = Instantiate(enemy4, posSpawnRight, transform.rotation) as GameObject;
        //enemyObj4.GetComponent<Enemy4>().SetVellocity(false); 
        
        //GameObject enemyObj3 = Instantiate(enemy3, posSpawnRight, transform.rotation) as GameObject;
        //enemyObj3.GetComponent<Enemy3>().SetVellocity(false);
    }
}
