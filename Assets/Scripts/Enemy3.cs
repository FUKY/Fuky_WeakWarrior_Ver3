using UnityEngine;
using System.Collections;

public class Enemy3 : EnemyController
{
    private float timeAwakeEnemy;

    private bool colliderPlayer;

    public void PauseEnemy(bool left)
    {
        if (left == true)
        {
            if (transform.position.x >= -1.6f)
            {
                GetAnimatorEnemy.speed = 0f;
                GetRb2dEnemy.velocity = Vector2.zero;
                if (timeAwakeEnemy >= 0.5f)
                {
                    GetAnimatorEnemy.speed = 1f;
                    GetRb2dEnemy.velocity = new Vector2(2f, 0f);
                    if (colliderPlayer == true)
                    {
                        GetRb2dEnemy.velocity = Vector2.zero;
                    }
                }
                else
                    timeAwakeEnemy += Time.deltaTime;
            }
        }
        else
        {
            if (transform.position.x <= 1.6f)
            {
                GetAnimatorEnemy.speed = 0f;
                GetRb2dEnemy.velocity = Vector2.zero;
                if (timeAwakeEnemy >= 0.5f)
                {
                    GetAnimatorEnemy.speed = 1f;
                    GetRb2dEnemy.velocity = new Vector2(-2f, 0f);
                    if (colliderPlayer == true)
                    {
                        GetRb2dEnemy.velocity = Vector2.zero;
                    }
                }
                else
                    timeAwakeEnemy += Time.deltaTime;
            }
        }
    }

    void Update()
    {
        Dead();
        PauseEnemy(FacingRight);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        CheckCollision(col);
        if (col.tag == "Player")
        {
            colliderPlayer = true;
        }
    }
}
