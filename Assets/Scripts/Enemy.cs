using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;
    private Animator animatorEnemy;
    public int HPEnemy;


    //private Transform frontCheck;

    public GameObject attackArea;

    private GameController score;
    private PlayerController player;
    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        //frontCheck = transform.Find("frontCheck").transform;

        //rb2d.velocity = new Vector2(speed, 0f);
        score = GameObject.Find("GameController").GetComponent<GameController>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    //void FixedUpdate()
    //{
    //    Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position);
    //    foreach (Collider2D col in frontHits)
    //    {
    //        //Enemy1 chạm và đánh Player
    //        if (col.tag == "Player")
    //        {
    //            animatorEnemy.SetTrigger(attackEnemyState);
    //            rb2d.velocity = new UnityEngine.Vector2(0f, 0f);
    //        }
    //    }
    //    if (HP <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Update()
    {
        //Enemy1 bị chém trúng
        if (HPEnemy <= 0)
        {
            Destroy(gameObject);
            score.score ++;
        }
        Debug.Log(player.miss);
    }

    void HurtEnemy()
    {
        HPEnemy--;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            animatorEnemy.SetTrigger("attackEnemy");
            rb2d.velocity = new Vector2(0f, 0f);
        }
        if (col.tag == "DeathArea")
        {
            HurtEnemy();
            player.miss = false;
        }
        else
            player.miss = true;
        if (col.tag == "DeathAreaSkill")
        {
            HPEnemy = 0;
        }
    }

    public void SetVellocity(bool left)
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (left)
        {
            transform.localScale = new Vector2(1, 1);
            rb2d.velocity = new Vector2(speed, 0f);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
            rb2d.velocity = new Vector2(-speed, 0f);
        }
    }
    public void AttackOff()
    {
        attackArea.SetActive(false);
    }
    public void AttackOn()
    {
        attackArea.SetActive(true);
    }

}
