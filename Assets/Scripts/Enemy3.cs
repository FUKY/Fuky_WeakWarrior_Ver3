using UnityEngine;
using System.Collections;

public class Enemy3 : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;
    private Animator animatorEnemy;
    public int HPEnemy;
    
    public GameObject attackArea;

    private GameController score;
    private PlayerController player;

    private float timeAwakeEnemy;

    private bool colliderPlayer;
    private bool facingRight;

    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        score = GameObject.Find("GameController").GetComponent<GameController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //rb2d.velocity = new Vector2(speed, 0f);
    }

    void Update()
    {
        if (HPEnemy <= 0)
        {
            Destroy(gameObject);
            score.score ++;
        }

        if (facingRight==true)
        {
            if (transform.position.x >= -1.5f)
            {
                animatorEnemy.speed = 0f;
                rb2d.velocity = Vector2.zero;
                if (timeAwakeEnemy >= 0.5f)
                {
                    animatorEnemy.speed = 1f;
                    rb2d.velocity = new Vector2(2f, 0f);
                    if (colliderPlayer == true)
                    {
                        rb2d.velocity = Vector2.zero;
                    }
                }
                else
                    timeAwakeEnemy += Time.deltaTime;
            }
        } 
        else
        {
            if (transform.position.x <= 1.5f)
            {
                animatorEnemy.speed = 0f;
                rb2d.velocity = Vector2.zero;
                if (timeAwakeEnemy >= 0.5f)
                {
                    animatorEnemy.speed = 1f;
                    rb2d.velocity = new Vector2(-2f, 0f);
                    if (colliderPlayer == true)
                    {
                        rb2d.velocity = Vector2.zero;
                    }
                }
                else
                    timeAwakeEnemy += Time.deltaTime;
            }
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
            //rb2d.velocity = Vector2.zero;
            colliderPlayer = true;
        }
        if (col.tag == "DeathArea")
        {
            HurtEnemy();
            player.notMiss = true;
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
            facingRight = true;
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
            rb2d.velocity = new Vector2(-speed, 0f);
            facingRight = false;
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
