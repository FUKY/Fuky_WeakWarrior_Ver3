using UnityEngine;
using System.Collections;

public class BossLeftHandController : MonoBehaviour {
    public bool colPlayerLeft;
    public Rigidbody2D rb2dLeft;

    void Start()
    {
        rb2dLeft = GetComponent<Rigidbody2D>();
    }

    public void AttackLeft()
    {
        rb2dLeft.velocity = new Vector2(2f, 0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            rb2dLeft.velocity = new Vector2(-1f, 0f);
            colPlayerLeft = true;
        }
    }
    void Update()
    {
        if (colPlayerLeft == true && transform.position.x <= -3f)
        {
            rb2dLeft.velocity = Vector2.zero;
            colPlayerLeft = false;
        }
    }
}
