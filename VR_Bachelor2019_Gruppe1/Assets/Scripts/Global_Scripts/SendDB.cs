using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class SendDB : MonoBehaviour
{
    //Fill in your server data here.
    private string AddScoreURL = "www.ux.uis.no/~sirim/AddScore.php?";
    public FetchDB fetch;


    void Start()
    {
        Debug.Log("sending scores...");
        StartCoroutine(AddScore()); // Sending scores.
    }

    public IEnumerator AddScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("Player_Name", Global.username);
        form.AddField("Score", Global.score);
        form.AddField("LevelID", Global.levelID);

        UnityWebRequest www = UnityWebRequest.Post(AddScoreURL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("an error occured when posting new score...\n" + www.error);
        }
        else
        {
            
            Debug.Log("score successfully added...");
            Debug.Log(www.downloadHandler.text);
            fetch.Fetch();
        }
    }
}
