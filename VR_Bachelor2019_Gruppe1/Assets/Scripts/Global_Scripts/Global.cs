/* Global.cs - 02.04.2019 
 * Static class holding all static game variables that are used throughout the game.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Global
{
    // Getters and setters.
    public static string username { get; set; }
    public static int score { get; set; }
    public static int gameID { get; set; }
    public static int level { get; set; }

    public static int levelID {
        get { return (gameID + level); }
    }

    // List of scene titles
    public static List<string> scenes = new List<string> {
        "Hub",
        "MemoryGame",
        "AtomCrusherEasy",
        "EscapeAtoms",
        "GameOver"
    };

    // Loading the game over scene.
    public static IEnumerator GoToGameOver(int points)
    {
        yield return new WaitForSeconds(3);
        score = points;
        Debug.Log("gameover");
        SceneManager.LoadScene("GameOver");
    }
}
