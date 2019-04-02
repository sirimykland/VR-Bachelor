/* GameBehaviour.cs - 02.04.2019
 * Handles public variables and functionality used througout the game. 
 * Initialization when game starts, and finishes the game when it should end.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour {

    public TextMesh scoreText;
    public TextMesh livesText;
    public TextMesh timeText;
    public TextMesh gameText;

    public int score;
    public int lives;

    public bool gameOver;

    public AudioClip gameOverSound;
    private AudioSource source;

    private int seconds;
    private int minutes;

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
        seconds = 0;
        minutes = 0;
    }

    /* Checks, after every frame, if game should finish. Game is over when the player is out of lives.
     * Displays score and lives in-game.
     */ 
    void Update () {
        if (!gameOver)
        {
            UpdateTimer();
        }

        if (lives == 0)
        {
            GameOver();
        }
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }

    /* Sets bool gameOver to true to stop other functions from running. 
     * Displays final score and runs an animation on the remaining atoms in scene.
     */     
    void GameOver()
    {
        gameOver = true;
        gameText.text = "GAME OVER \n Final Score: " + score;
        source.PlayOneShot(gameOverSound, 0.15f);
        GameObject[] metalsInScene = GameObject.FindGameObjectsWithTag("Metal");
        GameObject[] nonMetalsInScene = GameObject.FindGameObjectsWithTag("NonMetal");
        foreach (GameObject metal in metalsInScene)
        {
            metal.GetComponent<Rigidbody>().useGravity = true;
        }
        foreach (GameObject nonMetal in nonMetalsInScene)
        {
            nonMetal.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    //Runs the timer shown in-game.
    private void UpdateTimer()
    {
        seconds = (int)Time.time % 60;
        minutes = (int)Time.time / 60;
        if (seconds < 10)
        {
            timeText.text = minutes.ToString() + ":0" + seconds.ToString();
        }
        else
        {
            timeText.text = minutes.ToString() + ":" + seconds.ToString();
        }

    }
}
