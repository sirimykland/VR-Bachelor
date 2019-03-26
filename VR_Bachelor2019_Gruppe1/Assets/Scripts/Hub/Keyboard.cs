using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour {
    private string playerName;
    private GameObject textBox;
    private GameObject keyBoardObject;
    //private GameObject playerInformation; info om tid og navn før spillet starter
    private GameObject startMemoryObject;

    
	// Use this for initialization
	void Start () {

        textBox = GameObject.FindGameObjectWithTag("NameOfPlayer");
        keyBoardObject = GameObject.FindGameObjectWithTag("Keyboard");

        //insert more buttons(doors/portals)

        startMemoryObject = GameObject.FindGameObjectWithTag("StartMemory");
        startMemoryObject.SetActive(false);
    }
    public void Enter_Onclick()
    {
        Debug.Log(textBox.GetComponent<Text>().text);
        playerName = textBox.GetComponent<Text>().text;
        Global.username = playerName;
        keyBoardObject.SetActive(false);

        //fler knapper settes aktive her
        startMemoryObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {

       // print(textObject.GetComponent<Text>().text);
    }
}
