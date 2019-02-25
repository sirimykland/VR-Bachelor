using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
    public Text message;
    public Text points;

    private void Start()
    {
        message.text = "Well done " + Global.username+",";
        points.text ="You scored "+ Global.score+ "points.";
    }
    public void ToHub_OnClick()
    {
        Debug.Log("To Hub button was clicked");
        SceneManager.LoadScene(Global.scenes[3]);
    }
}
