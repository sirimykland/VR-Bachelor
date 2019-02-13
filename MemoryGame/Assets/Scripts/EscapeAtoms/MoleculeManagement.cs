using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeManagement : MonoBehaviour {
    private bool _init = false;
    public Molecule[] Molecules;
    public Atom[] Atoms;


    // Use this for initialization
    void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        if (!_init)
            Initialize();

        
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

            //m.transform.parent = new GameObject(Atoms[index]);

            index++;
        }
        _init = true;
    }
}
