using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public float spawnTime;
    public float spawnDelay;

    public Vector2 posSpawnLeft;
    public Vector2 posSpawnRight;

    //public Enemy[] enemies;
    public int index;
    public GameObject[] listEnemy;

    float timeSpawner;
    float timeChange;
    int count = 0;

    public float waitTime;
    public float waitWaveTime;
    

    void Start()
    {
        //InvokeRepeating("Spawn", spawnDelay, spawnTime);
        StartCoroutine(Spawn());

    }

    void Update()
    {
        //Debug.Log(count + "index" +index);

        if (timeSpawner>=2.0f)
        {
            timeSpawner = 0;
            Change();
            //Spawn();
        } 
        else
            timeSpawner+=Time.deltaTime;
    }

    void Change()
    {
        //Spawn();
        if (count >= 6)
        {
            count = 0;
            if (index >= listEnemy.Length)
                index = 0;
            else
                index++;
        }
        else
            return;
    }
    //void Spawn()
    //{   
    //    int rand = Random.Range(1, 3);
    //    if (rand == 1)
    //    {
    //        SpawnLeft(index);
    //    }
    //    else
    //    {
    //        SpawnRight(index);
    //    }
    //}

    public IEnumerator Spawn()
    {
        while (true)
        {
            //chờ SpawnTime để ra 1 wave 3 enemy 
            if (count == 3)
                yield return new WaitForSeconds(waitWaveTime);

            //Chờ WaitTime để ra 1 enemy
            yield return new WaitForSeconds(waitTime);
            int rand = Random.Range(1, 3);
            if (rand == 1)
                SpawnLeft(index);
            else
                SpawnRight(index);
        }
    }

    void SpawnLeft(int index)
    {
        if (index == 3f)
        {
            GameObject enemyObj = Instantiate(listEnemy[index], posSpawnLeft, transform.rotation) as GameObject;
            enemyObj.GetComponent<Enemy4>().SetVellocity(true);
            count++;
        } 
        else
        {
            GameObject enemyObj = Instantiate(listEnemy[index], posSpawnLeft, transform.rotation) as GameObject;
            enemyObj.GetComponent<EnemyController>().SetVellocity(true);
            count++;
        }
        
    }

    void SpawnRight(int index)
    {
        if (index==3f)
        {
            GameObject enemyObj = Instantiate(listEnemy[index], posSpawnRight, transform.rotation) as GameObject;
            enemyObj.GetComponent<Enemy4>().SetVellocity(false);
        } 
        else
        {
            GameObject enemyObj = Instantiate(listEnemy[index], posSpawnRight, transform.rotation) as GameObject;
            enemyObj.GetComponent<EnemyController>().SetVellocity(false);
            count++;
        }
    }
}
