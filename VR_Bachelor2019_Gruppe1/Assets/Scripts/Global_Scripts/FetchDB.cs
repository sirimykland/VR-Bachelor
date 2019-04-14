using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class FetchDB : MonoBehaviour
{
    //Fill in your server data here.
    private string TopScoresURL = "www.ux.uis.no/~sirim/GetTop.php?";

    public int limit;
    public Scoreboard[] scoreboards;

    void Start()
    {
        Debug.Log("retrieving scores");
        foreach (Scoreboard s in scoreboards)
        {
            for (int i = 0; i < s.LevelID.Length; i++)
            {
                StartCoroutine(GetTopScores(s.LevelID[i], s.textboxes[i])); // Fetching scores.
            }
        }
    }

    IEnumerator GetTopScores(int levelID, Text textbox)
    {
        WWWForm form = new WWWForm();
        form.AddField("LevelID", levelID);
        form.AddField("Limit", limit);

        UnityWebRequest www = UnityWebRequest.Post(TopScoresURL, form);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("an error occured when feching scores from " + levelID + "...\n" + www.error);
            textbox.text = "An Error occured...\n" + www.error;
        }
        else
        {
            Debug.Log("sucessfully fetched from " + levelID);
            string jsonString = www.downloadHandler.text;
            Debug.Log(jsonString);
            ScoreList scores = new ScoreList();
            scores = ScoreList.CreateFromJSON(jsonString);
            Debug.Log(scores.ToString());
            textbox.text = scores.ToString();
        }
    }

    [Serializable]
    public class ScoreList
    {
        public List<PlayerScore> items;

        public static ScoreList CreateFromJSON(string jsonString)
        {
            Debug.Log("str");
            return JsonUtility.FromJson<ScoreList>("{\"items\":" + jsonString + "}");
        }

        public ScoreList()
        {
            items = new List<PlayerScore>();
        }

        override
        public string ToString()
        {
            Debug.Log("items count " + items.Count);
            string str = "";
            for (int i = 0; i < items.Count; i++)
            {
                str += items[i].ToString(i + 1) + "\n";
            }
            return str;
        }
    }

    [Serializable]
    public class PlayerScore
    {
        public int ScoreID;
        public string Player_Name;
        public int Score;

        public static PlayerScore CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<PlayerScore>(jsonString);
        }

        public string ToString(int i)
        {
            return i + ".\t" + Player_Name + "\t" + Score;
        }
    }

}
