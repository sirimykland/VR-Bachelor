using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    private void Update()
    {
        GameObject btn = GameObject.FindGameObjectWithTag("ToHub");
    }
    void ToHub_OnClick()
    {
        SceneManager.LoadScene(Global.scenes[3]);
    }
}
