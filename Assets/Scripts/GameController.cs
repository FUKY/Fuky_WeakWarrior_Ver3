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
        if (scoreText == null)
            return;
        else
            scoreText.text = "SCORE: " + score;

        if (player.dead == true)
        {
            if (scoreText == null)
                return;
            else
            {
                gameOver.text = "GAME OVER!\nYour Score: " + score;
                Destroy(scoreText);
            }
        }
    }

}
