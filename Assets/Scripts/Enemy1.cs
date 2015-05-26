using UnityEngine;
using System.Collections;

public class Enemy1 : EnemyController {

    void OnTriggerEnter2D(Collider2D col)
    {
        CheckCollision(col);
    }
    
}
