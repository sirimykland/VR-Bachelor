/* InitializeAtomCrusher.cs - 16.04.2019
 * Handels the opening scene in Atom Crusher. Allows the player to choose difficulty. 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeAtomCrusher : MonoBehaviour
{

    void OnTriggerEnter(Collider atom)
    {
        if (atom.gameObject.CompareTag("Metal"))
        {
            Global.level = 1;
            StartCoroutine(WaitToStart());
            SceneManager.LoadScene("AtomCrusherEasy");
        }
        if (atom.gameObject.CompareTag("NonMetal"))
        {
            Global.level = 2;
            StartCoroutine(WaitToStart());
            SceneManager.LoadScene("AtomCrusherNormal");
        }
    }


    public static IEnumerator WaitToStart()
    {
        Debug.Log("wait 3 sec");
        yield return new WaitForSeconds(3);
    }

}