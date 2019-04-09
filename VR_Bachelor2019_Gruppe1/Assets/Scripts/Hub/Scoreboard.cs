using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Text Title;
    public Text[] textboxes;
    public string gameName;
    public int[] levelID;

    ///Fill in your server data here.
    private string Top3ScoresURL = "www.ux.uis.no/~sirim/GetTop3.php?";

    //Our standard Unity functions
    //Called as soon as the class is activated.
    void Start()
    {
        Title.GetComponent<Text>().text = gameName;
        Debug.Log("retrieving scores");
        StartCoroutine(GetTopScores()); // We post our scores.
    }

    IEnumerator GetTopScores()
    {
        for( int i = 0 ; i < levelID.Length ; i++)
        {
            WWWForm form = new WWWForm();
            form.AddField("LevelID", levelID[i]);

            UnityWebRequest www = UnityWebRequest.Post(Top3ScoresURL, form );
            
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("an error occured when feching scores from " + gameName + "Level "+levelID[i]+"...\n" + www.error);
            }
            else
            {
                Debug.Log("sucessfully fetched from " + gameName + levelID[i]);
                //string[] textlist = www.downloadHandler.text.Split(new string[] { "\n", "\t" }, System.StringSplitOptions.RemoveEmptyEntries);
                textboxes[i].text = www.downloadHandler.text;
                Debug.Log(www.downloadHandler.text);
            }
        }

    }
}
