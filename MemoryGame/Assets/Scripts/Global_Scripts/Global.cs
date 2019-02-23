using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Global
{
    // Use GlobalVariables.TimeToPlay= x sec to determine the amount of time the players can play the game
    
    public static int level { get; set; }
    public static int MGLvl { get; set; }

    //public static int userID { get; set; }
    public static string username { get; set; }
    public static int score { get; set; }
    public static string gameChoice { get; set; }

    public static bool gameOver { get; set; }


    public static List<string> scenes = new List<string> { "Hub", "MemoryGame", "GameStop" };

    public static List<Player> playerScores = new List<Player> { };

    private static Player player;
    private static bool demoScoresAdded = false;


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
        player = new Player(username, score);
        bool scoreAdded = false;
        if (playerScores == null)
        {
            playerScores.Add(player);
        }
        else
        {
            for (int i = 0; i < playerScores.Count; i++)
            {
                if (player.playerscore > playerScores[i].playerscore)
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
        for (int i = 0; i < playerScores.Count; i++)
        {

            scoreText += number.ToString() + ". " + playerScores[i].playerName + "  -  " + playerScores[i].playerscore + " POENG" + "\n";
            number++;
        }
        return scoreText;
    }
    public static void ResetPlayer() {
        username = "test";
        score = 2;
        gameChoice = scenes[1];
    }


    public static IEnumerator GoToGameOver()
    {
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
