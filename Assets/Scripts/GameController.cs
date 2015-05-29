using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public int score = 0;
    private PlayerController player;
    private Text gameOver;
    private Text scoreText;
    public GameObject boss;
    private Spawner spawner;
    public AudioClip[] clips;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameOver = GameObject.Find("GameOver").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }
    int flag = 0;
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

            boss.GetComponent<BossController>().StopAllCoroutines();
            spawner.StopAllCoroutines();
            SoundController.instanceSound.PlaySingle(clips[0]);
        }
        if (score >= 3)
        {
            // Gọi Boss khi đủ Score
            if (boss == null)
            {
                Debug.Log("boss die");
                //spawner.StartCoroutine(spawner.Spawn());
                flag++;
            }
            else
            {
                Debug.Log("boss alive");
                boss.SetActive(true);
                spawner.StopAllCoroutines();
                //spawner.SetActive(false);
            }
            //spawner.GetComponent<Spawner>().CancelInvoke();   
        }
        if (flag == 1) 
        {
            spawner.StartCoroutine(spawner.Spawn());
        }

    }

    public void RestartGame()
    {
        Application.LoadLevel("WW");
    }

}
