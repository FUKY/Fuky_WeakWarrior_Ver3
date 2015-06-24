using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator animatorPlayer;
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
    private Transform frontCheck;

    public bool attackMiss;

    private float timeAwake;
    private bool missing;
    public AudioClip[] playerSounds;

    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
        animatorPlayer.runtimeAnimatorController = listAnimator[state];
        attackPlayerState = Animator.StringToHash("attackPlayer");
        rb2dPlayer = GetComponent<Rigidbody2D>();
        buttonSkill = GameObject.Find("ButtonSkill").GetComponent<ButtonSkillController>();
        frontCheck = transform.Find("FrontCheckMiss").transform;
    }
    void Update()
    {
        //Bay qua phải
        if (facingRight == true) 
        {
            if (transform.position.x >= 3f)
            {
                transform.position = new Vector2(-3.0f, 0f);
                skilling = true;
            }
            if (skilling == true && transform.position.x >= 0f) 
            {
                rb2dPlayer.velocity = Vector2.zero;
                transform.position = Vector2.zero;
                skilling = false;
                animatorPlayer.SetTrigger("skillPlayer");
                animatorPlayer.speed = 1f;
            }
        }
        else
        {
            //Bay qua trái
            if (transform.position.x <= -3f)
            {
                transform.position = new Vector2(3f, 0f);
                skilling = true;
            }
            if (skilling == true && transform.position.x <= 0f)
            {
                rb2dPlayer.velocity = Vector2.zero;
                transform.position = Vector2.zero;
                skilling = false;
                animatorPlayer.SetTrigger("skillPlayer");
                animatorPlayer.speed = 1f;
            }
        }

        //Chém miss thì Player bị dừng
        if (missing == true)
        {
            if (timeAwake >= 0.5f)
            {
                animatorPlayer.speed = 1f;
                timeAwake = 0f;
                missing = false;
            }
            else
                timeAwake += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        Collider2D[] frontHits = Physics2D.OverlapCircleAll(frontCheck.position, 1.0f);
        foreach (Collider2D col in frontHits)
        {
            Debug.Log(col);
            if (col.tag == "Enemy")
            {
                attackMiss = false;
            }
            else
                attackMiss = true;
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
    public void AttackMiss()
    {
        SoundController.instanceSound.PlaySingle(playerSounds[2]);
        if (attackMiss == true)
        {
            animatorPlayer.speed = 0;
            missing = true;
        }
        if (attackMiss == false) 
        {
            animatorPlayer.speed = 1;
            missing = false;
            attackMiss = true;
        }
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
            rb2dPlayer.velocity = new Vector2(-10f, 0f);
            animatorPlayer.speed = 0f;
            deathAreaSkill.SetActive(true);
        }
        else
        {
            rb2dPlayer.velocity = new Vector2(10f, 0f);
            animatorPlayer.speed = 0f;
            deathAreaSkill.SetActive(true);
        }
        
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "AttackArea")
        {
            if (state == 1)
                SoundController.instanceSound.PlaySingle(playerSounds[1]);
            else
                SoundController.instanceSound.PlaySingle(playerSounds[0]);
            state--;
            UpdateState(state);
        }
    }
    public void UpdateState(int statePlayer)
    {
        if (statePlayer <= 0)
        {
            gameObject.SetActive(false);
            dead = true;
        } 
        else
            animatorPlayer.runtimeAnimatorController = listAnimator[statePlayer];
    }
   
}
