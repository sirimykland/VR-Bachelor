using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;


public class FetchDB : MonoBehaviour
{
    ///Fill in your server data here.
    private string privateKey = "ebba3c2d54e68e4bdd33b638d48cb4ab";
    private string Top3ScoresURL = "http://ux.uis.no/~vrbach19/GetTop3.php?";

    
    public Scoreboard[] scoreboards;

    //Our standard Unity functions
    //Called as soon as the class is activated.
    void Start()
    {
        Debug.Log("sending entry");
        StartCoroutine(GetTopScores()); // We post our scores.
    }

    IEnumerator GetTopScores()
    {
        foreach (Scoreboard g in scoreboards)
        {

            UnityWebRequest www = UnityWebRequest.Post(Top3ScoresURL, "game=" + g.gameName);
            //www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("an error occured when posting new score...\n" + www.error);
            }
            else
            {
                //string[] textlist = GetTop3.text.Split(new string[] { "\n", "\t" }, System.StringSplitOptions.RemoveEmptyEntries);
                g.textbox.text = www.downloadHandler.text;
            }
        }

    }
}
