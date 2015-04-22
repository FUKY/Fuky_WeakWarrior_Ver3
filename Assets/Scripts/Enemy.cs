using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private float speed = 2f;
    private Rigidbody2D rb2d;
    private Animator animatorEnemy;
    public int HP;

    private int attackEnemyState;

    private Transform frontCheck;
    private bool attacked;

    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        frontCheck = transform.Find("frontCheck").transform;
        rb2d.velocity = new Vector2(speed, 0f);
        attackEnemyState = Animator.StringToHash("attackEnemy");

    }

    void FixedUpdate()
    {
        Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position);
        foreach (Collider2D col in frontHits)
        {
            //Enemy1 chạm và đánh Player
            if (col.tag == "Player")
            {
                animatorEnemy.SetTrigger(attackEnemyState);
                rb2d.velocity = new UnityEngine.Vector2(0f, 0f);
            }
        }
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    //void Update()
    //{
    //    //Enemy1 bị chém trúng
    //    if (HP <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Hurt()
    {
        HP--;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            animatorEnemy.SetTrigger(attackEnemyState);
            rb2d.velocity = new Vector2(0f, 0f);
        }
        if (col.tag == "DeathArea")
        {
            Hurt();
        }
    }
}
