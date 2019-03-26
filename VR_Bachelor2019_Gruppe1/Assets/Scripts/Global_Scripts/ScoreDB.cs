using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreDB: MonoBehaviour
{

    private string privateKey = "ebba3c2d54e68e4bdd33b638d48cb4ab";
    private string AddScoreURL = "http://ux.uis.no/~vrbach19/AddScore.php?";

  //Called as soon as the class is activated.
  void Start()
  {
      Debug.Log("sending entry");
      StartCoroutine(AddScore()); // We post our scores.
  }

  ///The encryption function: http://wiki.unity3d.com/index.php?title=MD5
  private string Md5Sum(string strToEncrypt)
  {
      System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
      byte[] bytes = ue.GetBytes(strToEncrypt);

      System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
      byte[] hashBytes = md5.ComputeHash(bytes);

      string hashString = "";

      for (int i = 0; i < hashBytes.Length; i++)
      {
          hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
      }

      return hashString.PadLeft(32, '0');
  }

  ///Our IEnumerators
  IEnumerator AddScore()
  {
      string hash = Md5Sum(Global.username + Global.score + Global.gameChoice + privateKey);


        WWWForm form = new WWWForm();
        form.AddField("username", UnityWebRequest.EscapeURL(Global.username));
        form.AddField("score", Global.score);
        form.AddField("game", Global.gameChoice);
        form.AddField("hash", hash);

        UnityWebRequest www = UnityWebRequest.Post(AddScoreURL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("an error occured when posting new score...\n"+ www.error);
        }
        else
        {
            Debug.Log("score successfully added...");
        }
  }

    /*void Start()
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
    }*/
}
