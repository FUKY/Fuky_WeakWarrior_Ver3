using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;
    private Animator animatorEnemy;
    public int HPEnemy;
    
    public GameObject attackArea;

    private Score score;
    
    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(2f, 0f);
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void Update()
    {
        if (HPEnemy <= 0)
        {
            Destroy(gameObject);
            score.score += 1;
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
            rb2d.velocity = new Vector2(-3f, 0f);
            //transform.position = new Vector2(-2f, -0.8f);
            Debug.Log(HPEnemy);
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
