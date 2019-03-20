using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
    public Text message;
    public Text points;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        message.text = "Well done " + Global.username +",";
        points.text ="You scored "+ Global.score + "points.";
        Debug.Log(Global.username + "  " + Global.score);
    }
    public void ToHub_OnClick()
    {

        //Destroy(gameObject);
        Debug.Log("To Hub button was clicked");
        SceneManager.LoadScene(Global.scenes[0]);
        
    }
}
