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
    GameObject gamemanagerObject;
    GameObject cardlistObject;
    GameObject levelbuttonsObject;
    GameObject menuObject;

    private void Start()
    {
        levelbuttonsObject = GameObject.FindGameObjectWithTag("LevelButtons");
        gamemanagerObject = GameObject.FindGameObjectWithTag("GameManager");
        cardlistObject = GameObject.FindGameObjectWithTag("CardList");
        menuObject = GameObject.FindGameObjectWithTag("Menu");

        ActivateObjects(false);

        levels = new List<Material[]>();
        levels.Add(level1);
        levels.Add(level2);
        levels.Add(level3);
        playerText.text = "Player: " + Global.username;
        
    } 
    private void ActivateObjects(bool state)
    {
        levelbuttonsObject.SetActive(!state);
        gamemanagerObject.SetActive(state);
        cardlistObject.SetActive(state);
        menuObject.SetActive(state);
    }

    // Update is called once per frame
    public void Level_OnClick(int i){
        Debug.Log("Level "+i+" chosen");
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
