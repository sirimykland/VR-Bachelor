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

    public void StartButton_OnClick(Collider col)
    {
        Debug.Log("StartButton_OnClick(Collider col):  was entered");
        if (col.CompareTag("StartButton"))
        {
            Debug.Log("startbutton was clicked");
            Global.gameChoice = "MemoryGame";
            SceneManager.LoadScene("MemoryGame");
        }
    }

    // lag en metoder per portal
    public void StartMemory_OnClick()
    {
            Debug.Log("Memorybutton was clicked");
            Global.gameChoice = "MemoryGame";
        SceneManager.UnloadSceneAsync("Hub");
        SceneManager.LoadScene("MemoryGame");//Global.scenes[1]);
            
    }

    public void StartAtomCrusher_OnClick()
    {
        Debug.Log("AtomCrusher was clicked");
        Global.gameChoice = "AtomCrusher";
        SceneManager.UnloadSceneAsync(Global.scenes[0]);
        SceneManager.LoadScene("AtomCrusherNormal");//Global.scenes[1]);
        
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
        Global.ResetPlayer();
        Debug.Log("HubController loaded");
	}
}
