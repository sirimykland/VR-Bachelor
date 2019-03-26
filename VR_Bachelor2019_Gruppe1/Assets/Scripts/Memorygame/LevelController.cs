/* LevelController.cs
 * 
 */

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

    private GameObject gameManagerObject;
    private GameObject cardCanvas;

    // Called on scene loading, and conserves Global.cs script 
    private void Awake(){
        DontDestroyOnLoad(gameObject);
    }

    void Start(){
        gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        cardCanvas = GameObject.FindGameObjectWithTag("CardList");
       
        gameManagerObject.SetActive(false);
        cardCanvas.SetActive(false);

        levels = new List<Material[]>();
        levels.Add(level1);
        levels.Add(level2);
        levels.Add(level3);

        playerText.text = "Spiller: " + Global.username; 
    }

    // On level clicked, cards are initialized, and the LevelController are destroyed.
    public void level_OnClick(int i){
        GameObject.FindGameObjectWithTag("LevelButtons").SetActive(false);
        gameManagerObject.SetActive(true);
        cardCanvas.SetActive(true);
        gamemanager.InitializeCards(levels[i-1],i);
        Global.level = i;

        Destroy(gameObject);
    }
}
