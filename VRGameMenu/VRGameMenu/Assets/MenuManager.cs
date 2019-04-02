using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;


public class MenuManager : MonoBehaviour
{
     public Material farge;
    public GameObject planet;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Application.persistentDataPath);
    }

    public void Game_OnClick()
    {
        planet.GetComponent<Renderer>().material = new Material(farge);
        //Debug(Application.persistentDataPath + "/MemoryGame/VR_Bachelor2019_Gruppe1.exe");
        //Process.Start(@"C:/Users/IDE/Documents/Builds/Menu/MemoryGame/VR_Bachelor2019_Gruppe1.exe");
        Process.Start(Application.dataPath+"/MemoryGame/VR_Bachelor2019_Gruppe1.exe");
        Process.Start(@"/MemoryGame/VR_Bachelor2019_Gruppe1.exe");

    }
}
