
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HubController : MonoBehaviour {

    
    private string playerName;
    private GameObject textBox;
    private GameObject keyBoardObject;
    private GameObject messageObject;
    private GameObject[] startPortal;

    public GameObject eventSystem;

    // Use this for initialization
    void Start()
    {
        //finds all Objects with these tags
        textBox = GameObject.FindGameObjectWithTag("NameOfPlayer");
        keyBoardObject = GameObject.FindGameObjectWithTag("KeyBoard");
        messageObject = GameObject.FindGameObjectWithTag("Message");
        startPortal = GameObject.FindGameObjectsWithTag("Portal");

        ActivateObjects(true);
        messageObject.GetComponent<Text>().text = "Skriv på tastaturet ved å trykke på: \n" +
            "1. Touchpad-knappen med tommelen \n" +
            "2. Trigger-knappen med pekefingeren \n\n" +
            "Du kan telepotere deg rundt på gresset ved å trykke på Touchpadden mens du peker på gulvet";


    }

    // lag en metoder per portal
    public void StartGame_OnClick(int i)
    {
        Debug.Log("startbutton for " + Global.scenes[i] + " was clicked");
        Global.gameChoice = Global.scenes[i];
        SceneManager.LoadScene(Global.scenes[i]);
    }

    public void Enter_Onclick()
    {
        Debug.Log(textBox.GetComponent<Text>().text);
        playerName = textBox.GetComponent<Text>().text;
        Global.username = playerName;
        ActivateObjects(false);
        messageObject.GetComponent<Text>().text = "Velg spill ved å klikke\n på tilhørende dør.";
    }

    private void ActivateObjects(bool state)
    {
        textBox.SetActive(state);
        keyBoardObject.SetActive(state);
        //messageObject.SetActive(!state);
        foreach(GameObject g in startPortal)
        {
            g.SetActive(!state);
        }
        
    }
}
