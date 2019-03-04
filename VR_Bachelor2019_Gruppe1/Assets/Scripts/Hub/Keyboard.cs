using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour {
    private string playerName;
    private GameObject textBox;
    private GameObject keyBoardObject;
    //private GameObject playerInformation; info om tid og navn før spillet starter
    private GameObject startGameObject;
    private GameObject startMemoryObject;
    private GameObject startAtomObject;
    private ScoreDB DBRef;
    
	// Use this for initialization
	void Start () {
        GameObject DBRefObject = GameObject.FindWithTag("DB");
        if (DBRefObject != null)
        {
            DBRef = DBRefObject.GetComponent<ScoreDB>();
        }
        textBox = GameObject.FindGameObjectWithTag("NameOfPlayer");
        keyBoardObject = GameObject.FindGameObjectWithTag("Keyboard");
        keyBoardObject.SetActive(true);

        //insert more buttons(doors/portals)
        startMemoryObject = GameObject.FindGameObjectWithTag("StartMemory");
        startMemoryObject.SetActive(false);

        startAtomObject = GameObject.FindGameObjectWithTag("StartAtom");
        startAtomObject.SetActive(false);
        Debug.Log("keyboard loaded");
    }
    public void Enter_Onclick()
    {
        //print(textBox.GetComponent<Text>().text);
        playerName = textBox.GetComponent<Text>().text;
        Global.username = playerName;
        //DBRef.addScore(0);
        //playerInformation.GetComponent<Text>().text = "Hei " + playerName + ", du har " + GlobalVariables.timeToPlay.ToString() + "sekunder på å komme så langt du kan. Trykk på startknappen når du er klar";
        //print(playerInformation.GetComponent<Text>().text);
        //playerInformation.SetActive(true);

        keyBoardObject.SetActive(false);

        //fler knapper settes aktive her
        startMemoryObject.SetActive(true);
        startAtomObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {

       // print(textObject.GetComponent<Text>().text);
    }
}
