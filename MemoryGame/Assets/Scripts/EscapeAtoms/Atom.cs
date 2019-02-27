using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Atom : MonoBehaviour {
    public int _noElectrons;
    public string _name;
    private bool _give;
    
    void Start(){
        gameObject.AddComponent<Rigidbody>();  
    }
    
    public void giveAwayState()
    {
        if (_noElectrons > 4 && _noElectrons < 8)
            _give = true;
        else
            _give = false;
    }
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

    public bool Give
    {
        get { return _give; }
        set { _give = value; }
    }

    void fullMolecule(){
        if (_noElectrons == 8)
        {
            //explode animation
        }
        
    }


}
