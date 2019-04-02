using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public GameManager gamemanager;
    public Material[] level1;
    public Material[] level2;
    public Material[] level3;

    private static List<Material[]> levels;
    public Text playerText;
    public Text levelText;


    // Start is called before the first frame update
    private GameObject gamemanagerObject;
    private GameObject cardlistObject;
    private GameObject[] levelbuttonObjects;
    private GameObject menuObject;
    private GameObject messageObject;

    private void Start()
    {
        levelbuttonObjects = GameObject.FindGameObjectsWithTag("LevelButtons");
        gamemanagerObject = GameObject.FindGameObjectWithTag("GameManager");
        cardlistObject = GameObject.FindGameObjectWithTag("CardList");
        menuObject = GameObject.FindGameObjectWithTag("Menu");
        messageObject = GameObject.FindGameObjectWithTag("Message");

        ActivateObjects(false);

        levels = new List<Material[]>{ level1, level2, level3};

        playerText.text = "Spiller: " + Global.username;
        messageObject.GetComponent<Text>().text = "Velg level ved å trykke på: \n" +
            "1. Touchpad-knappen med tommelen \n" +
            "2. og samtidig trykke på Trigger-knappen med pekefingeren\n\n" +
            "Du kan telepotere deg rundt i rommet ved å trykke på Touchpadden mens du peker på gulvet";

    } 

    // hides and shows objects, based on where in the game the player are
    private void ActivateObjects(bool state)
    {
        foreach (GameObject g in levelbuttonObjects)
        {
            g.SetActive(!state);
        }
        gamemanagerObject.SetActive(state);
        cardlistObject.SetActive(state);
        menuObject.SetActive(state);
    }

    // initilizes the game at level i
    public void Level_OnClick(int i){
        ActivateObjects(true);
        gamemanager.backsides = levels[i-1];
        gamemanager.InitializeCards();
        levelText.text = "Level: "+i;
        Global.level = i;
    }

    public void NewLevel_OnClick() {
        SceneManager.LoadScene(Global.scenes[1]);
    }

    public void Quit_OnClick(){
        SceneManager.LoadScene(Global.scenes[0]);
    }

}
