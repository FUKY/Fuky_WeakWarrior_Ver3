using UnityEngine;
using System.Collections;

public class Enemy2 : EnemyController {
    public void IdleOn()
    {
        attackArea.SetActive(false);
        if (FacingRight == true)
        {
            GetRb2dEnemy.velocity = new Vector2(speed / 2, 0f);
        }
        else
        {
            GetRb2dEnemy.velocity = new Vector2(-speed / 2, 0f);
        }
    }

}
