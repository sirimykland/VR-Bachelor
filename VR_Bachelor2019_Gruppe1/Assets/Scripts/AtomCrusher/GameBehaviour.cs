﻿using System.Collections;
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

<<<<<<< HEAD
=======
    private float time;

>>>>>>> master
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
<<<<<<< HEAD
=======
        time = 0;
>>>>>>> master
    }

    //Checks, after every frame, if game should finish
    void Update () {
<<<<<<< HEAD
=======
        time = Time.timeSinceLevelLoad;

>>>>>>> master
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

    //Sets bool gameOver to true to stop other functions. Displays final score and runs an animation on the remaining atom in scene.
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
<<<<<<< HEAD
        seconds = (int)Time.time % 60;
        minutes = (int)Time.time / 60;
=======
        //seconds = (int)Time.time % 60;
        //minutes = (int)Time.time / 60;
        seconds = (int)time % 60;
        minutes = (int)time / 60;
>>>>>>> master
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
