using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Text title;
    public Text[] textboxes;

    [SerializeField]
    private int[] levelID;


    public int[] LevelID{

        get {
            if (levelID.Length == 0)
            {
                levelID = new int[1];
                levelID[0] = Global.levelID;
                Debug.Log(levelID[0]);
            }
            return levelID;
        }
   }
}
