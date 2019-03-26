using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Text Title;
    public Text textbox;
    public string gameName;

    void Start()
    {
        Title.text = gameName;
    }
}
