using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour {
    public int _noElectrons;
    public string _name;

	
	// Update is called once per frame
	public int attractable()
    {
        // some counting of electrons
        return 0;
    }

    public int NoElectrons
    {
        get { return _noElectrons; }
        set { _noElectrons = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    void fullMolecule(){
        if (_noElectrons == 8)
        {
            //explode animation
        }
        
    }


}
