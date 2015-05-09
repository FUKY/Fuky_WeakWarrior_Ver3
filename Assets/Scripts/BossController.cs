using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    private Rigidbody2D bossHead;
    private Rigidbody2D bossLeftHand;
    private Rigidbody2D bossRightHand;

    private PlayerController player;
    private GameController score;

    public float HPEnemy;

	void Start () 
    {
        bossHead = GameObject.Find("BossHead").GetComponent<Rigidbody2D>();
        bossHead.velocity = new Vector2(0f, 1f);

        bossLeftHand = GameObject.Find("BossLeftHand").GetComponent<Rigidbody2D>();
        bossRightHand = GameObject.Find("BossRightHand").GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        score = GameObject.Find("GameController").GetComponent<GameController>();

        InvokeRepeating("Attack", 1f, 1f);

	}
	
	void Update ()
    {

        if (HPEnemy <= 0)
        {
            Destroy(gameObject);
            score.score++;
        }

        if (bossHead.transform.position.y >= 0.45f)
        {
            bossHead.velocity = Vector2.zero;
        }
	}

    void Attack()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
            AttackLeftHand();
        else
            AttackRightHand();
    }

    void AttackLeftHand()
    {
        bossLeftHand.velocity = new Vector2(1f, 0f);

        if (bossLeftHand.position.x <= -3f)
        {
            bossLeftHand.velocity = Vector2.zero;
        }
    }
    void AttackRightHand()
    {
        bossRightHand.velocity = new Vector2(-1f, 0f);

        if (bossRightHand.position.x <= -3f)
        {
            bossRightHand.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            bossLeftHand.velocity = new Vector2(-1f, 0f);
            bossRightHand.velocity = new Vector2(1f, 0f);
        }
        if (col.tag == "DeathArea")
        {
            HurtEnemy();
            player.miss = true;
        }
        if (col.tag == "DeathAreaSkill")
        {
            HPEnemy = 0;
        }
    }

    void HurtEnemy()
    {
        HPEnemy--;
    }
}
