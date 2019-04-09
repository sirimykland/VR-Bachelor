using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreDB: MonoBehaviour
{
    private string AddScoreURL = "www.ux.uis.no/~sirim/AddScore.php?";
    private string Top10ScoresURL = "www.ux.uis.no/~sirim/GetTop10.php?";

    public Text textbox;

  //Called as soon as the class is activated.
  void Start()
  {
      Debug.Log("sending entry");
      StartCoroutine(AddScore()); // We post our scores.
      StartCoroutine(GetTopScores());
  }

  ///Our IEnumerators
  IEnumerator AddScore()
  {
        WWWForm form = new WWWForm();
        form.AddField("Player_Name", Global.username);
        form.AddField("Score", Global.score);
        form.AddField("LevelID", Global.levelID);
        

        UnityWebRequest www = UnityWebRequest.Post(AddScoreURL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("an error occured when posting new score...\n"+ www.error);
        }
        else
        {
            Debug.Log("score successfully added...");
            Debug.Log(www.downloadHandler.text);
        }
  }

    IEnumerator GetTopScores()
    {

        WWWForm form = new WWWForm();
        form.AddField("LevelID", Global.levelID);

        UnityWebRequest www = UnityWebRequest.Post(Top10ScoresURL, form);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("an error occured when feching scores from level " + Global.levelID + "...\n" + www.error);
        }
        else
        {
            Debug.Log("sucessfully fetched new top 10 from " + Global.levelID);
            string[] textlist = www.downloadHandler.text.Split(new string[] { "\f" }, System.StringSplitOptions.RemoveEmptyEntries);
            textbox.text = textlist[0];
            textbox.text += textlist[textlist.Length - 1];
            Debug.Log( textlist[1] + www.downloadHandler.text);
        }
        

    }

}
