using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public Vector3 offset;
    private Transform player;
    private SpriteRenderer healthBar;
    private Vector3 healthScale;
    private PlayerController playerController;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthBar = GetComponent<SpriteRenderer>();
        healthScale = transform.localScale;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        transform.position = player.position + offset;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.material.color = Color.Lerp(Color.green, Color.yellow, 1.0f - playerController.state * 1f);
        healthBar.transform.localScale = new Vector3(healthScale.x * playerController.state * 0.5f + 0.5f, 0.8f, 1.0f); 
    }

}
