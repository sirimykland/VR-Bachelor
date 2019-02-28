using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Start()
    {
        
        gamemanagerObject = GameObject.FindGameObjectWithTag("GameManager");
        cardlistObject = GameObject.FindGameObjectWithTag("CardList");
       
        gamemanagerObject.SetActive(false);
        cardlistObject.SetActive(false);

        levels = new List<Material[]>();
        levels.Add(level1);
        levels.Add(level2);
        levels.Add(level3);
        playerText.text = "Player: " + Global.username;
        
    }
    // Update is called once per frame
    public void level_OnClick(int i){

        Debug.Log("Level "+i+" chosen");
        GameObject.FindGameObjectWithTag("LevelButtons").SetActive(false);
        gamemanagerObject.SetActive(true);
        cardlistObject.SetActive(true);
        gamemanager.backsides = levels[i-1];
        gamemanager.InitializeCards();
        levelText.text = "Level: "+i;
        Global.level = i;

        Destroy(gameObject);
    }
}
