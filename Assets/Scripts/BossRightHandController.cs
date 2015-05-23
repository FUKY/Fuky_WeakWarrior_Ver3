using UnityEngine;
using System.Collections;

public class BossRightHandController : MonoBehaviour {

    public bool colPlayerRight;
    public Rigidbody2D rb2dRight;

    void Start()
    {
        rb2dRight = GetComponent<Rigidbody2D>();
    }

    public void AttackRight()
    {
        rb2dRight.velocity = new Vector2(-2f, 0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            rb2dRight.velocity = new Vector2(1f, 0f);
            colPlayerRight = true;
        }
    }
    void Update()
    {
        if (colPlayerRight == true && transform.position.x >= 3f)
        {
            rb2dRight.velocity = Vector2.zero;
            colPlayerRight = false;
        }
    }
}
