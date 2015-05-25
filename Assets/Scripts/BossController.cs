using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    private BossHandController bossHandController;
    public Rigidbody2D bossHead; 

    private GameController score;

    public float HPEnemy;

    float timeWaitBossAttack;

	void Start () 
    {
        bossHead.velocity = new Vector2(0f, 1f);        
        
        score = GameObject.Find("GameController").GetComponent<GameController>();
        bossHandController = gameObject.GetComponentInChildren<BossHandController>();
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
            bossHandController.AttackHand(true);
        if (rand == 2)
            bossHandController.AttackHand(false);

        Debug.Log(rand);
    }
    

    public void HurtEnemy()
    {
        HPEnemy--;
    }


}
