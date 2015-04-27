using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public int score = 0;
    private PlayerController player;
    private Text gameOver;
    private Text scoreText;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameOver = GameObject.Find("GameOver").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "SCORE: " + score;
        if (player.dead == true)
        {
            gameOver.text = "GAME OVER!\nYour Score: " + score;
            Destroy(scoreText);
        }
    }

}
