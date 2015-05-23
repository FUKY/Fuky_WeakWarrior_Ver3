using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    public BossLeftHandController bossLeftHandController;
    public BossRightHandController bossRightHandController;
    private Rigidbody2D bossHead;


    private PlayerController player;
    private GameController score;

    public float HPEnemy;

    float timeWaitBossAttack;

	void Start () 
    {
        bossHead = GameObject.Find("BossHead").GetComponent<Rigidbody2D>();
        bossHead.velocity = new Vector2(0f, 1f);
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        score = GameObject.Find("GameController").GetComponent<GameController>();

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
            bossLeftHandController.AttackLeft();
        if (rand == 2)
            bossRightHandController.AttackRight();

        Debug.Log(rand);
    }
    

    public void HurtEnemy()
    {
        HPEnemy--;
    }


}
