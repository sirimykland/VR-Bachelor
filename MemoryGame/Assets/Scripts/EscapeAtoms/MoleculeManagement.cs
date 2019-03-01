using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeManagement : MonoBehaviour {
    private bool _init = false;
    public Molecule[] Molecules;
    public Atom[] Atoms;
    public Atom[] wallAtoms;


    // Use this for initialization
    void Start () {
        Initialize();
	}

    // Update is called once per frame
	void Update(){
        if(Molecules== null)
            Global.gameOver = true;
    }

    void Initialize()
    {
        ListShuffeler.Shuffle(Atoms);
        int index = 0;
        foreach(Molecule m in Molecules)
        {
            if (index>Atoms.Length)
                index++;

            while(Atoms[index].NoElectrons >= 7) {
                index++;
            }
            m.starterAtom = index++; //post incrementation
        }
        foreach(Molecule m in Molecules)
        {
            m.setupWall();
        }
        _init = true;
    }

    void IsGameOver()
    {
        if (Global.gameOver)
            StartCoroutine(Global.GoToGameOver());
    }


}
