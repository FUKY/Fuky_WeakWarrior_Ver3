using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public Vector3 offset;
    private SpriteRenderer healthBar;
    private Vector3 healthScale;
    public PlayerController playerController;

    void Awake()
    {
        healthBar = GetComponent<SpriteRenderer>();
        healthScale = transform.localScale;
    }

    void Update()
    {
        UpdateHealthBar(playerController.state, playerController.transform.position);
    }

    void UpdateHealthBar(int health, Vector3 obj)
    {
        transform.position = obj + offset;
        healthBar.material.color = Color.Lerp(Color.green, Color.yellow, 1.0f - health * 1.0f);
        healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.25f + 0.25f, 0.8f, 1.0f); 
    }
}
