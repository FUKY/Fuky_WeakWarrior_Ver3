using UnityEngine;
using System.Collections;

public class Enemy6 : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;
    private Animator animatorEnemy;
    public int HPEnemy;

    public GameObject attackArea;

    private GameController score;
    private PlayerController player;
    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        score = GameObject.Find("GameController").GetComponent<GameController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb2d.velocity = new Vector2(1f, 0f);
    }

    void Update()
    {
        //Enemy1 bị chém trúng
        if (HPEnemy <= 0)
        {
            Destroy(gameObject);
            score.score++;
        }
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
            rb2d.velocity = Vector2.zero;
        }
        if (col.tag == "DeathArea")
        {
            HurtEnemy();
            //player.notMiss = true;
        }
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
