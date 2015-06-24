using UnityEngine;
using System.Collections;

public class Enemy2 : EnemyController
{   
    public void IdleOn()
    {
        if (FacingRight == true)
            GetRb2dEnemy.velocity = new Vector2(speed / 2, 0f);
        else
            GetRb2dEnemy.velocity = new Vector2(-speed / 2, 0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        CheckCollision(col);
        if (col.tag=="DeathArea")
        {
            GetAnimatorEnemy.SetTrigger("downEnemy");
            if (FacingRight == true)
            {
                GetRb2dEnemy.velocity = new Vector2(-speed, 0f);
            }
            else
            {
                GetRb2dEnemy.velocity = new Vector2(speed, 0f);
            }
        }
    }
}
