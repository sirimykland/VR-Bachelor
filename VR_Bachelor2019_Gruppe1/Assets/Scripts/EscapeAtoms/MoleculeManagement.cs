using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoleculeManagement : MonoBehaviour {
    private bool _init = false;
    public Molecule[] Molecules;
    public GameObject[] Atoms;
   


    // Use this for initialization
    void Start () {
        Initialize();
	}

    // Update is called once per frame
	void Update(){
        if(Molecules== null)
            StartCoroutine(GameOver()); 
    }


    // set up wall of 9 atoms
    void Initialize()
    {
        ListShuffeler.Shuffle(Atoms);
        int index = 0;
        foreach(Molecule m in Molecules)
        {
            if (index>Atoms.Length)
                index++;

            while(Atoms[index].GetComponent<Atom>().Outer != 0) {
                index++;
            }
            m.SetupWall(Atoms[index++].GetComponent<Atom>()); //post incrementation
        }

        _init = true;
    }

    /*void testing()
    {
        int index = 0;
        ListShuffeler.Shuffle(Atoms);
        foreach (Molecule m in Molecules)
        {
            if (index > Atoms.Length)
                index++;

            while (Atoms[index].GetComponent<Atom>().Outer != 0)
            {
                index++;
            }
            m.SetupWall(Atoms[index++].GetComponent<Atom>()); //post incrementation
        }
    }*/

    public IEnumerator GameOver()
    {
        Global.score = 200;//points;
        Global.gameOver = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(Global.scenes[3]);
    }


}
