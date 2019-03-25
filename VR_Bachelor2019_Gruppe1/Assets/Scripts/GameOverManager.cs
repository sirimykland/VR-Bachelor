using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
    public Text title;
    public Text message;

    void Start()
    {
        switch (Global.gameChoice)
        {
            case "MemoryGame":
                title.text = "MemoryGame Level "+ Global.level;
                message.text = "Godt jobbet " + Global.username + ", \nDu fikk " + Global.score + " poeng!";
                break;
            default:
                title.text = Global.gameChoice;
                message.text = "Godt jobbet " + Global.username + ", \nDu fikk " + Global.score + " poeng!";
                break;
        }

    }
    public void ToHub_OnClick()
    {
        Debug.Log("To Hub button was clicked");
        SceneManager.LoadScene(Global.scenes[0]);
    }
}
