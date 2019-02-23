using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreDB: MonoBehaviour
{

    void Start()
    {
        Debug.Log("sending entry");
        StartCoroutine(cur_postRequest("https://us-central1-uisvr2019.cloudfunctions.net/userentry"));
    }

    IEnumerator cur_postRequest(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("game", Global.gameChoice);
        //form.AddField("userID", Global.userID);
        form.AddField("username", Global.username);
        form.AddField("score", Global.score);

        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.Send();

        if (uwr.isError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}
