using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour {

    public Text scoreText;
    public Text livesText;
    public Text gameText;
    public int score;
    public int lives;

    public bool gameOver;

    public AudioClip gameOverSound;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Initialization
    void Start () {
        gameOver = false;
        lives = 3;
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
        gameText.text = "";
    }

    //Checks, after every frame, if game should finish
    void Update () {
        if (lives == 0)
        {
            GameOver();
        }
    }

    //Sets bool gameOver to true to stop other functions. Displays final score
    void GameOver()
    {
        gameOver = true;
        gameText.text = "GAME OVER \n Final Score: " + score;
        source.PlayOneShot(gameOverSound, 0.15f);
    }
}
