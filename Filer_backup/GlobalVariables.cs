using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public static class GlobalVariables
{
    // Use GlobalVariables.TimeToPlay= x sec to determine the amount of time the players can play the game
    //public static double timeRemaining { get; set; }
    //public static float timeToPlay = 100;
    //public static float timeNow;
    public static int score { get; set; }
    public static int level { get; set; }
    public static int MGLvl { get; set; }
    public static string name { get; set; }
    public static string gameChoice { get; set; }
    //private static int tlf { get; set; }
    //public static Stopwatch gameTimer;
    public static bool gameOver { get; set; }
    //public static System.Timers.Timer aTimer;
    //public static string timertekst;
    //private static int timePassed;
    
    public static List<string> scenes = new List<string> { "Hub", "MemoryGame", "GameStop" };

    public static List<Player> playerScores = new List<Player> { };
    //public static Time gameStartTime;

    //public static float playerTime;
    //public static float timeLeft;
    private static Player player;
    private static bool demoScoresAdded = false;

    //trenger ikke denne om spillet  har  enkle levels
    /*public static void addScore (int add_score) {
        score += add_score;

    }*/

    public static void InsertSomePlayersOnScoreBoard()
    {
        if (!demoScoresAdded)
        {
            playerScores.Add(new Player("SONDRE", 1500));
            playerScores.Add(new Player("LARS-ESPEN", 1350));
            playerScores.Add(new Player("LEIV", 1300));
            demoScoresAdded = true;
        }
    }

    public static void InsertNewPlayerScore()
    {
        player = new Player(name, score);
        bool scoreAdded = false;
        if(playerScores == null)
        {
            playerScores.Add(player);
        }
        else
        {
            for(int i = 0; i<playerScores.Count; i++)
            {
                if(player.playerscore > playerScores[i].playerscore)
                {
                    playerScores.Insert(i, player);
                    scoreAdded = true;
                    break;
                }
            }
            if (!scoreAdded)
            {
                playerScores.Add(player);
               
            }
        }  
    }

    public static string PlayerScoreToString()
    {
        string scoreText = "";
        int number = 1;
        for(int i=0; i<playerScores.Count; i++)
        {
            
            scoreText += number.ToString() + ". " + playerScores[i].playerName + "  -  " + playerScores[i].playerscore + " POENG" +"\n";
            number++;
        }
        return scoreText;
    }

    
    /*
    public static void InitiateTimer()
    {
        gameStartTime = new Time();
        gameTimer = new Stopwatch();
        gameTimer.Start();
        CheckIfItIsGameOver();
    }

    public static void StoppTimer()
    {
        if (gameTimer == null)
        {
            Console.WriteLine("Error -> Timer has not been initiated. Please call the GlobalVariables.InitiateTimer() method before calling GlobalVariables.StoppTimer()");
        }
        else
        {
            gameTimer.Stop();  
        }
    }

    public static void StartTimer()
    {
        if (gameTimer == null)
        {
            InitiateTimer();
        }
        else
        {
            gameTimer.Start();    
        }
    }

    private static void CheckIfItIsGameOver()
    {
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(100);
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }

    private static void OnTimedEvent(System.Object source, ElapsedEventArgs e)
    {
        timeRemaining = (double)timeToPlay - gameTimer.Elapsed.TotalSeconds;

         
        if(timeRemaining <= 0){
            gameOver = true;
            aTimer.Stop();
            aTimer.Dispose();
            gameTimer.Reset();
        }
        timertekst = "Dette er tid: "+ (int)gameTimer.Elapsed.TotalSeconds;
    }
     */


    public static IEnumerator GoToGameOver() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
    }
   

    public class Player
    {
        public string playerName;
        public int playerscore;

        public Player(string playerName, int playerscore)
        {
            this.playerName = playerName;
            this.playerscore = playerscore;
        }
    }
}
