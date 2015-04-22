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

    public bool attack;

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
        attack = true;
        deathArea.SetActive(attack);
    }

    public void AttackOff()
    {
        attack = false;
        deathArea.SetActive(attack);
    }
}
