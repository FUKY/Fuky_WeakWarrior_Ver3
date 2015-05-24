using UnityEngine;
using System.Collections;

public class BossLeftHandController : MonoBehaviour {
    public bool colPlayerLeft;
    public bool isAttackedLeft;
    private Rigidbody2D rb2dLeft;

    public BossController bossController;
    public PlayerController playerController;

    void Start()
    {
        rb2dLeft = GetComponent<Rigidbody2D>();       
    }
    
    public void AttackLeft()
    {
        rb2dLeft.velocity = new Vector2(1f, 0f);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            colPlayerLeft = true;
            rb2dLeft.velocity = new Vector2(-1f, 0f);
            playerController.state--;
            playerController.animatorPlayer.runtimeAnimatorController = playerController.listAnimator[playerController.state];
        }
        if (col.tag == "DeathArea")
        {
            isAttackedLeft = true;
            rb2dLeft.velocity = new Vector2(-1f, 0f);
            bossController.HurtEnemy();
            playerController.notMiss = true;
        }
    }
    void Update()
    {
        if ((colPlayerLeft == true && transform.position.x <= -3f) || (isAttackedLeft == true && transform.position.x <= -3f)) 
        {
            rb2dLeft.velocity = Vector2.zero;
            colPlayerLeft = false;
            isAttackedLeft = false;
        }

    }
}
