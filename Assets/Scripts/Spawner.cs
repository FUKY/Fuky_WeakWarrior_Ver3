using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public float spawnTime;
    public float spawnDelay;

    public Vector2 posSpawnLeft;
    public Vector2 posSpawnRight;
    
    public int enemiesPerWave;
    int index;
    public GameObject[] listEnemy;

    float timeSpawner;
    float timeChange;
    int count = 0;

    public float waitTime;
    public float waitWaveTime;
    

    void Start()
    {
        StartCoroutine(Spawn());

    }

    void Update()
    {

        if (timeSpawner>=2.0f)
        {
            timeSpawner = 0;
            Change();
        } 
        else
            timeSpawner+=Time.deltaTime;
    }

    void Change()
    {
        if (count >= enemiesPerWave * 2)
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

    public IEnumerator Spawn()
    {
        while (true)
        {
            //Thời gian giữa từng wave 
            if (count == enemiesPerWave)
                yield return new WaitForSeconds(waitWaveTime);

            //Chờ WaitTime để spawn 1 enemy
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
