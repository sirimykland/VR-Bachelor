using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;


public class FetchDB : MonoBehaviour
{
    ///Fill in your server data here.
    /*private string Top3ScoresURL = "www.ux.uis.no/~sirim/GetTop3.php?";

    
    public Scoreboard[] scoreboards;

    //Our standard Unity functions
    //Called as soon as the class is activated.
    void Start()
    {
        Debug.Log("retrieving scores");
        StartCoroutine(GetTopScores()); // We post our scores.
    }

    IEnumerator GetTopScores()
    {
        foreach (Scoreboard g in scoreboards)
        {

            UnityWebRequest www = UnityWebRequest.Post(Top3ScoresURL, "GameID=" + g.gameID);
            //www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("an error occured when feching scores from "+g.gameName+"...\n" + www.error);
            }
            else
            {
                Debug.Log("sucessfully fetched from " + g.gameName);
                //string[] textlist = GetTop3.text.Split(new string[] { "\n", "\t" }, System.StringSplitOptions.RemoveEmptyEntries);
                g.setText((string) www.downloadHandler.text);
                Debug.Log(www.downloadHandler.text);
            }
        }

    }*/
}
