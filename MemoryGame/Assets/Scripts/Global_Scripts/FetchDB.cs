using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FetchDB : MonoBehaviour
{
    public void addScore(int score)
    {
        Debug.Log("sending entry");
        StartCoroutine(postRequest("https://us-central1-uisvr2019.cloudfunctions.net/userentry"));
    }

    IEnumerator postRequest(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("game", Global.gameChoice);
        form.AddField("username", Global.username);
        form.AddField("score", Global.score);

        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}
