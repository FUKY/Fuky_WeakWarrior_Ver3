using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed; 
    public int HPEnemy;
    private Animator animatorEnemy;

    public GameObject attackArea;

    private GameController score;
    public PlayerController playerController;

    private Rigidbody2D rb2dEnemy;
    public Rigidbody2D GetRb2dEnemy
    {
        get { return rb2dEnemy; }
        set { rb2dEnemy = value; }
    }
   
    bool facingRight;
    public bool FacingRight
    {
        get { return facingRight; }
        set { facingRight = value; }
    }
    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        rb2dEnemy = GetComponent<Rigidbody2D>();
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
    public void HurtEnemy()
    {
        HPEnemy--;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            animatorEnemy.SetTrigger("attackEnemy");
            rb2dEnemy.velocity = Vector2.zero;
        }
        if (col.tag == "DeathArea")
        {
            HurtEnemy();
            animatorEnemy.SetTrigger("downEnemy");
            playerController.notMiss = true;
            if (facingRight == true)
            {
                rb2dEnemy.velocity = new Vector2(-speed / 2, 0f);
            }
            else
            {
                rb2dEnemy.velocity = new Vector2(speed / 2, 0f);
            }
        }
        if (col.tag == "DeathAreaSkill")
        {
            HPEnemy = 0;
        }
    }
    public void SetVellocity(bool left)
    {
        rb2dEnemy = GetComponent<Rigidbody2D>();
        if (left)
        {
            transform.localScale = new Vector2(1, 1);
            rb2dEnemy.velocity = new Vector2(speed, 0f);
            facingRight = true;
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
            rb2dEnemy.velocity = new Vector2(-speed, 0f);
            facingRight = false;
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
