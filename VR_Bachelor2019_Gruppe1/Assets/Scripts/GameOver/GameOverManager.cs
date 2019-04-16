using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
    public Text title;
    public Text message;
    public Text scoreboard;

    private void Start()
    {
        switch (Global.gameID)
        {
            case 100:
                title.text = "Molecular Memory Level "+ Global.level;
                message.text = "Godt jobbet " + Global.username + ", \nDu fikk " + Global.score + " poeng!";
                break;
            case 200:
                title.text = "Atom Crusher Level " + Global.level;
                message.text = "Godt jobbet " + Global.username + ", \nDu fikk " + Global.score + " poeng!";
                break;
            case 300:
                title.text = "Atom Thrower";
                message.text = "Godt jobbet " + Global.username + ", \nDu fikk " + Global.score + " poeng!";
                break;
            default:
                title.text = "Feil";
                message.text = "Godt jobbet " + Global.username + ", \nDu fikk " + Global.score + " poeng!";
                break;
        }

    }
    public void ToHub_OnClick()
    {
        SceneManager.LoadScene(Global.scenes[0]);
    }
}
