﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;
    private Animator animatorEnemy;
    public int HPEnemy;

    private int attackEnemyState;

    public GameObject attackArea;

    private Score score;

    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        attackEnemyState = Animator.StringToHash("attackEnemy");

        score = GameObject.Find("Score").GetComponent<Score>();
    }


    void Update()
    {
        //Enemy1 bị chém trúng
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
            animatorEnemy.SetTrigger(attackEnemyState);
            rb2d.velocity = new Vector2(0f, 0f);
        }
        if (col.tag == "DeathArea")
        {
            HurtEnemy();
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
