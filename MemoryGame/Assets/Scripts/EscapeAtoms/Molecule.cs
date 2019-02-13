using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule : MonoBehaviour {
    private List<Atom> _atomsList;
    // Use this for initialization
    public int _noElectrons;

    void Start()
    {
        _atomsList = new List<Atom>();
    }

    void OnCollisionEnter(Collision col)
    {
        //col.gameObject.tag== "Atom"
        if (col.gameObject.GetComponent<Atom>())
        {
            Atom _collidedAtom = col.gameObject.GetComponent<Atom>();
            if (_noElectrons + _collidedAtom.NoElectrons > 8){
                addAtom(_collidedAtom);
            }
                
        }
    }

    void addAtom(Atom newAtom){
        _atomsList.Add(newAtom);
    }

    void fullMolecule()
    {
        Destroy(gameObject);
    }



    void Update()
    {
    }
    public int NoElectrons
    {
        get { return _noElectrons; }
        set { _noElectrons = value; }
    }


}
