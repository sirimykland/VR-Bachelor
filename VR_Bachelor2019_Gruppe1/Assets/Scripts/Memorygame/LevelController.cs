/* LevelController.cs - 03.04.2019
 * Manages the Canvases and Levels of MemoryGame.
 * This includes activating and deactivating GameObjects 
 * and OnClick methods for the Menu and Level canvases.
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    // Public Prefabs and GameObjects assigned in Inspector.
    public GameManager gamemanager;
    public Material[] level1;
    public Material[] level2;
    public Material[] level3;
    public Text playerText;
    public Text levelText;

    // Private list and GameObjects used to manage the behaviour 
    // of the LevelContoller.
    private static List<Material[]> levels;
    private GameObject gamemanagerObject;
    private GameObject cardlistObject;
    private GameObject[] levelbuttonObjects;
    private GameObject menuObject;
    private GameObject messageObject;

    // Awake() is called after all objects are initialized.
    void Awake()
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

    // ActivateObjects() hides and shows multiple objects.
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

    // Level_OnClick() initilizes the game at level i.
    public void Level_OnClick(int i){
        ActivateObjects(true);
        gamemanager.backsides = levels[i-1];
        gamemanager.InitializeCards();
        levelText.text = "Level: "+i;
        Global.level = i;
    }

    // NewLevel_OnClick() loads this scene again.
    public void NewLevel_OnClick() {
        SceneManager.LoadScene(Global.scenes[1]);
    }

    // Quit_OnClick() loads Hub scene.
    public void Quit_OnClick(){
        SceneManager.LoadScene(Global.scenes[0]);
    }

}
