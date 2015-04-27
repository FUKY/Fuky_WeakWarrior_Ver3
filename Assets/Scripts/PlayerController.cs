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

    public bool dead;

    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
        animatorPlayer.runtimeAnimatorController = listAnimator[state];
        attackPlayerState = Animator.StringToHash("attackPlayer");
        deathArea.SetActive(false);

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
