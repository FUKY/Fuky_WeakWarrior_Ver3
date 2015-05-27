using UnityEngine;
using System.Collections;

public class Enemy4 : EnemyController
{
    void OnTriggerEnter2D(Collider2D col)
    {
        CheckCollision(col);
        if (col.tag == "Player")
        {
            GetRb2dEnemy.gravityScale = 0f;
        }
        if (col.tag == "DeathArea")
        {
            HurtEnemy();
            GetPlayerController.notMiss = true;
        }
        else
            GetPlayerController.notMiss = false;
    }

    public void SetVellocity(bool left)
    {
        GetRb2dEnemy = GetComponent<Rigidbody2D>();
        if (left)
        {
            transform.localScale = new Vector2(1, 1);
            GetRb2dEnemy.AddForce(new Vector2(140f, 70f));
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
            GetRb2dEnemy.AddForce(new Vector2(-140f, 70f));
        }
    }  
    
    //float index;
    //void Fly(float amplitudeX, float amplitudeY, float omegaX, float omegaY)
    //{
    //    index += Time.deltaTime;
    //    float x = amplitudeX * Mathf.Cos(omegaX * index);
    //    float y = (amplitudeY * Mathf.Sin(omegaY * index));
    //    transform.localPosition = new Vector3(x, y, 0);
    //}
    //public void Update()
    //{
    //    Fly(5f,2f,2f,7f);
    //}
}
