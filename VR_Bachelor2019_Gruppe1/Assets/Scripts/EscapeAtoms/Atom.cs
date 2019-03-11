using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Atom : MonoBehaviour {
    public int electrons;
    public string atomname;

    public int Outer { get; set; }
    public int Give { get; set; }
    

    public void Start()
    {
        OuterShell();
    }

    public void SetValues(int elect, string name)
    {
        electrons = elect;
        atomname = name;
        OuterShell();
    }
    /* give meaning:
     * 0: give electrons
     * 1: give and receive (Hydrogen only)
     * 2: receive electrons
     * 3: full outer shell
     */
    public void GiveAwayState()
    {
        if (Outer == 0 || Outer == 8){
            Give = 3;
        }else if (Outer <= 4)
        {
            Give = 0;
        }else if (Outer >= 5 )
        {
            Give=2;
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
            Outer = 1;
            Give = 1;
        }else if (electrons >= 2)
        {
            Outer = (electrons - 2) % 8;
            //Debug.Log("Outer = " + (electrons - 2) % 8);
            GiveAwayState();
        }
    }
    
}
