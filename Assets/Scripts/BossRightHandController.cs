using UnityEngine;
using System.Collections;

public class BossRightHandController : MonoBehaviour {

    public bool colPlayerRight;
    public bool isAttackedRight;
    private Rigidbody2D rb2dRight;
    public float speedAttack;

    public BossController bossController;
    public PlayerController playerController;

    void Start()
    {
        rb2dRight = GetComponent<Rigidbody2D>();
    }

    public void AttackRight()
    {
        rb2dRight.velocity = new Vector2(-speedAttack, 0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            rb2dRight.velocity = new Vector2(1f, 0f);
            colPlayerRight = true;
            playerController.state--;
            playerController.UpdateState(playerController.state);
        }
        if (col.tag == "DeathArea" || col.tag == "DeathAreaSkill") 
        {
            isAttackedRight = true;
            rb2dRight.velocity = new Vector2(1f, 0f);
            bossController.HurtEnemy();
            playerController.notMiss = true;
        }
    }
    void Update()
    {
        if ((colPlayerRight == true && transform.position.x >= 3f)
            || (isAttackedRight == true && transform.position.x >= 3f)) 
        {
            rb2dRight.velocity = Vector2.zero;
            colPlayerRight = false;
            isAttackedRight = false;
        }
    }
}
