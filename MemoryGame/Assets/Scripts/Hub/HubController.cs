//Hentet fra "VR Application for the Faculty
// of Science and Technology"
// av Oanæs, Sondre
//Idsø, Leiv Erling
//Kolberg, Lars-Espen


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SG_GameController : MonoBehaviour {
   
    public GameObject scoreboard;

    public void StartGame_Onclick()
    {
        SceneManager.LoadScene(Global.scenes[1]);
    }

    // lag en metoder per portal
    public void StartMemory_Onclick()
    {
        Global.gameChoice = "MemorygGame";
        SceneManager.LoadScene(Global.gameChoice);
    }

    void Start () {
        // lage et scoreboard per game, bruk loop til å fylle dem
        scoreboard = GameObject.FindGameObjectWithTag("ScoreBoard");
        Global.level = 1;
        Global.MGLvl = 1;
        Global.gameOver = false;
        Global.score = 0;
        Global.InsertSomePlayersOnScoreBoard();
        scoreboard.GetComponent<Text>().text = Global.PlayerScoreToString();
	}
}
