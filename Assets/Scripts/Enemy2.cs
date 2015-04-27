using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;
    private Animator animatorEnemy;
    public float HPEnemy;
    
    public GameObject attackArea;

    private GameController score;
    
    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d.velocity = new Vector2(2f, 0f);
        score = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
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
            rb2d.velocity = new Vector2(0f, 0f);
        }
        if (col.tag == "DeathArea")
        {
            HurtEnemy();
            animatorEnemy.SetTrigger("downEnemy");
            rb2d.velocity = new Vector2(-2f, 0f);
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

    public void IdleOn()
    {
        animatorEnemy.SetTrigger("idleEnemy");
        attackArea.SetActive(false);
        rb2d.velocity = new Vector2(2f, 0f);
    }
}
