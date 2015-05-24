﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator animatorPlayer;
    public RuntimeAnimatorController[] listAnimator;
    public int state;
    static int attackPlayerState;

    public GameObject deathArea;
    public GameObject deathAreaSkill;

    public bool dead;

    private Rigidbody2D rb2dPlayer;

    private bool skilling;
    private float waitTime;
    public float skillTime;
    public bool skillIsOn;
    private bool facingRight;

    private ButtonSkillController buttonSkill;

    public bool notMiss;

    private float timeAwake;
    private bool missing;

    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
        animatorPlayer.runtimeAnimatorController = listAnimator[state];
        attackPlayerState = Animator.StringToHash("attackPlayer");
        deathArea.SetActive(false);
        deathAreaSkill.SetActive(false);
        rb2dPlayer = GetComponent<Rigidbody2D>();

        buttonSkill = GameObject.Find("ButtonSkill").GetComponent<ButtonSkillController>();
        
    }
    void Update()
    {
        //Bay qua phải
        if (facingRight == true) 
        {
            if (transform.position.x >= 3f)
            {
                transform.position = new Vector2(-3f, -0.6f);
                skilling = true;
            }
            if (skilling == true && transform.position.x >= 0f)
            {
                rb2dPlayer.velocity = new Vector2(0f, 0f);
                skilling = false;
                animatorPlayer.SetTrigger("skillPlayer");
                animatorPlayer.speed = 1f;
                SkillOff();
            }
        }
        else
        {
            //Bay qua trái
            if (transform.position.x <= -3f)
            {
                transform.position = new Vector2(3f, -0.6f);
                skilling = true;
            }
            if (skilling == true && transform.position.x <= 0f)
            {
                rb2dPlayer.velocity = new Vector2(0f, 0f);
                skilling = false;
                animatorPlayer.SetTrigger("skillPlayer");
                animatorPlayer.speed = 1f;
                SkillOff();
            }
        }



        //Chém miss thì Player bị dừng
        if (missing == true)
        {
            if (timeAwake >= 0.5f)
            {
                animatorPlayer.speed = 1f;
                timeAwake = 0f;               

            }
            else
                timeAwake += Time.deltaTime;
        }
    }
    
    public void FlipLeft()
    {
        if (animatorPlayer == null)
            return;
        else
        {
            animatorPlayer.SetTrigger(attackPlayerState);
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
            facingRight = false;
        }
    }
    public void FlipRight()
    {
        if (animatorPlayer == null)
            return;
        else
        {
            animatorPlayer.SetTrigger(attackPlayerState);
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
            facingRight = true;
        }
    }

    

    public void AttackOn()
    {
        deathArea.SetActive(true);
    }

    public void AttackOff()
    {
        deathArea.SetActive(false);
    }
    public void SkillOff()
    {
        deathAreaSkill.SetActive(false);
        skillIsOn = false;
    }


    public void SkillOn()
    {
        if (buttonSkill.canSkill == true)
        {
            animatorPlayer.SetTrigger("skillPlayer");
            skillIsOn = true;
        }
        else
        {
            skillIsOn = false;
        }
    }
    public void SkillActive()
    {
        if (facingRight == false)
        {
            deathAreaSkill.transform.position = new Vector2(0.6f, -0.4f);
            rb2dPlayer.velocity = new Vector2(-10f, 0f);
            animatorPlayer.speed = 0f;
            deathAreaSkill.SetActive(true);
        }
        else
        {
            deathAreaSkill.transform.position = new Vector2(-0.6f, -0.4f);
            rb2dPlayer.velocity = new Vector2(10f, 0f);
            animatorPlayer.speed = 0f;
            deathAreaSkill.SetActive(true);
        }
    }

    public void ActtackMiss()
    {
        if (notMiss == false)
        {
            animatorPlayer.speed = 0;
            deathArea.SetActive(false);
            missing = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "AttackArea")
        {
            if (state <= 0)
            {
                Destroy(gameObject);
                dead = true;
            }
            else
            {
                state--;
                animatorPlayer.runtimeAnimatorController = listAnimator[state];

            }
        }
    }
   
}
