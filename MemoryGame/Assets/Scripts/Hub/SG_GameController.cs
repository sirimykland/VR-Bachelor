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
    //public ParticleSystem particles;
    public GameObject scoreboard;

    public void StartGame_Onclick()
    {
        SceneManager.LoadScene(GlobalVariables.scenes[1]);
    }
    public void StartMemory_Onclick()
    {
        GlobalVariables.gameChoice = "MemorygGame";// GlobalVariables.scenes[1];
        SceneManager.LoadScene(GlobalVariables.gameChoice);
    }

    void Start () {
        scoreboard = GameObject.FindGameObjectWithTag("ScoreBoard");
        GlobalVariables.level = 1;
        GlobalVariables.MGLvl = 1;
        GlobalVariables.gameOver = false;
        GlobalVariables.score = 0;
        //GlobalVariables.timeToPlay = 120;
        GlobalVariables.InsertSomePlayersOnScoreBoard();
        scoreboard.GetComponent<Text>().text = GlobalVariables.PlayerScoreToString();
	}
}
