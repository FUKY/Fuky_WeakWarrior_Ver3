using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    private BossHandController bossHandController;
    public Rigidbody2D bossHead; 

    private GameController score;

    public int HPEnemy;

    float timeWaitBossAttack;
    public bool dead;

	void Start () 
    {
        bossHead.velocity = new Vector2(0f, 1f);        
        
        score = GameObject.Find("GameController").GetComponent<GameController>();
        bossHandController = gameObject.GetComponentInChildren<BossHandController>();
	}
	void Update ()
    {
        //Debug.Log(HPEnemy);      
        Dead();
        if (bossHead.transform.position.y >= 0.45f)
        {
            bossHead.velocity = Vector2.zero;
        }
        // Attack Player
        if (timeWaitBossAttack >= 4)
        {
            Attack();
            timeWaitBossAttack = 0;
        }
        else
            timeWaitBossAttack += Time.deltaTime;

	}

    void Attack()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
            bossHandController.AttackHand(true);
        if (rand == 2)
            bossHandController.AttackHand(false);
        //Debug.Log(rand);
    }

    public void Dead()
    {
        if (HPEnemy <= 0)
        {
            Destroy(gameObject);
            score.score++;
            dead = true;
        }
    }

    public void HurtEnemy()
    {
        HPEnemy--;
    }


}
