using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public AtomShelfReplacer[] placeholders;


    public void ToHub_OnClick()
    {
        SceneManager.LoadScene(Global.scenes[0]);
    }

    public void Restart_OnClick()
    {
        SceneManager.LoadScene(Global.scenes[3]);
    }

    public void CleanShelf_OnClick()
    {   foreach(AtomShelfReplacer p in placeholders) 
            p.CleanUpShelf();
    }

}
