//Hentet fra "VR Application for the Faculty
// of Science and Technology"
// av Oanæs, Sondre
//Idsø, Leiv Erling
//Kolberg, Lars-Espen

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HubController : MonoBehaviour {

    public GameObject scoreboard;

    // lag en metoder per portal

    public void StartGame(int gameindex)
    {
        Debug.Log(Global.scenes[gameindex]+"button was clicked");
        Global.gameChoice = Global.scenes[gameindex];
        SceneManager.LoadScene(Global.scenes[1]);
    }


    public void StartMemory_OnClick()
    {
        Debug.Log("Memorybutton was clicked");
        Global.gameChoice = "MemoryGame";
        SceneManager.LoadScene(Global.scenes[1]);
            
    }


    public void StartAtomCrusher_OnClick()
    {
        Debug.Log("AtomCrusher was clicked");
        Global.gameChoice = "AtomCrusherNomal";
        SceneManager.LoadScene(Global.scenes[2]);
        
    }


    void Start () {
        // lage et scoreboard per game, bruk loop til å fylle dem
        //Debug.Log(" player name"+ Global.username);
        scoreboard = GameObject.FindGameObjectWithTag("ScoreBoard");
        Global.gameOver = false;
        Global.score = 0;
        Global.InsertSomePlayersOnScoreBoard();
        scoreboard.GetComponent<Text>().text = Global.PlayerScoreToString();
        Debug.Log("HubController loaded");
	}
}
