using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Atom : MonoBehaviour {
    public int electrons;
    public string atomname;


    public int outer;
    public int state;

    // public because some atoms ar instantiated in Molucule.cs (AddAtom();)
    void Start(){
        OuterShell();
    }

    /* give meaning:
     * 0: give electrons
     * 1: give and receive (Hydrogen only)
     * 2: receive electrons
     * 4: full outer shell
     */
    public void State()
    {
        if (outer == 0 || outer == 8){
            state = 4;
        }else if (outer <= 4)
        {
            state = 0;
        }else if (outer >= 5 )
        {
            state=2;
        }
    }
    public int Electrons
    {
        get { return electrons; }
        set { electrons = value; }
    }
    public string Name
    {
        get { return atomname; }
        set { atomname = value; }
    }
    private void OuterShell()
    {
        if (electrons ==1)
        {
            outer = 1;
            state = 1;
        }else if (electrons >= 2)
        {
            outer = (electrons - 2) % 8;
            State();
        }
    }
    
}
