using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{

    private Animator animatorPlayer;
    public RuntimeAnimatorController[] listAnimator;
    public int state;
    static int attackPlayerState;

    public GameObject deathArea;

    public bool attackPlayer;

    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
        animatorPlayer.runtimeAnimatorController = listAnimator[state];
        attackPlayerState = Animator.StringToHash("attackPlayer");
    }
    
    public void FlipLeft()
    {
        animatorPlayer.SetTrigger(attackPlayerState);
        Vector3 theScale = transform.localScale;
        theScale.x = -1;
        transform.localScale = theScale;        
    }
    public void FlipRight()
    {
        animatorPlayer.SetTrigger(attackPlayerState);
        Vector3 theScale = transform.localScale;
        theScale.x = 1;
        transform.localScale = theScale;
    }

    public void AttackOn()
    {
        attackPlayer = true;
        deathArea.SetActive(attackPlayer);
    }

    public void AttackOff()
    {
        attackPlayer = false;
        deathArea.SetActive(attackPlayer);
    }

    void HurtPlayer()
    {
        state--;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "AttackArea")
        {
            if (state <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                state--;
                animatorPlayer.runtimeAnimatorController = listAnimator[state];
            }
        }
    }
   
}
