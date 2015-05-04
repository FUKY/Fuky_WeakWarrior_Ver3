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

    private bool temp;
    private float waitTime;
    public float skillTime;
    public bool skillIsOn;

    private ButtonSkillController buttonSkill;

    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
        animatorPlayer.runtimeAnimatorController = listAnimator[state];
        attackPlayerState = Animator.StringToHash("attackPlayer");
        deathArea.SetActive(false);
        deathAreaSkill.SetActive(false);
        rb2dPlayer = GetComponent<Rigidbody2D>();

        buttonSkill=GameObject.Find("ButtonSkill").GetComponent<ButtonSkillController>();
    }
    void Update()
    {
        if (transform.position.x <= -3f)
        {
            transform.position = new Vector2(3f, -0.6f);
            temp = true;
        }
        if (temp == true && transform.position.x <= 0f)
        {
            rb2dPlayer.velocity = new Vector2(0f, 0f);
            temp = false;
            animatorPlayer.SetTrigger("skillPlayer");
            animatorPlayer.speed = 1f;
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
    public void SkillLeft()
    {
        deathAreaSkill.transform.position = new Vector2(0.6f, -0.4f);
        rb2dPlayer.velocity = new Vector2(-10f, 0f);
        animatorPlayer.speed = 0f;
        deathAreaSkill.SetActive(true);
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
