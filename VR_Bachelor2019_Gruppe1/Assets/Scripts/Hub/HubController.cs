
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HubController : MonoBehaviour {

    
    private string playerName;
    private GameObject textBox;
    private GameObject keyBoardObject;
    //private GameObject playerInformation; info om tid og navn før spillet starter
    private GameObject startMemoryObject;
    private GameObject startAtomCrusherObject;
    private GameObject startEscapeAtomsObject;

    public GameObject eventSystem;

    // Use this for initialization
    void Start()
    {

        textBox = GameObject.FindGameObjectWithTag("NameOfPlayer");
        keyBoardObject = GameObject.FindGameObjectWithTag("Keyboard");

        //insert more buttons(doors/portals)

        startMemoryObject = GameObject.FindGameObjectWithTag("StartMemory");
        startAtomCrusherObject = GameObject.FindGameObjectWithTag("StartAtomCrusher");
        startEscapeAtomsObject = GameObject.FindGameObjectWithTag("StartEscapeAtoms");
        ActivateObjects(true);

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
    }

    private void ActivateObjects(bool state)
    {
        textBox.SetActive(state);
        keyBoardObject.SetActive(state);
        startMemoryObject.SetActive(!state);
        startAtomCrusherObject.SetActive(!state);
        startEscapeAtomsObject.SetActive(!state);
    }
}
