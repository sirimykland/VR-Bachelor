/* Atom.cs - 04.04.2019
 * Contains the characteristics of an Atom, no behaviour.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour {

    // Atom values identifying the atomtype, set in Inspector
    public int electrons;
    public string atomname;


    // Public Atom getters/variables, set in script, hidden in Inspector
    public int outer; 
    public int state;

    void Start(){
        SetState();
    }

    /* SetState() calculates the values of outer and state
     * with these values of state meaning:
     *      0: give electrons
     *      1: give and receive (Hydrogen only)
     *      2: receive electrons
     *      4: full outer shell
     */
    public void SetState()
    {
        if (electrons == 1)
        {
            outer = 1;
            state = 1;
        }else if(electrons >1)
        {
            outer = (electrons - 2) % 8;

            if (outer == 0 || outer == 8) {
                state = 4;
            } else if (outer <= 4)
            {
                state = 0;
            } else if (outer >= 5)
            {
                state = 2;
            }
        }
    }
    
}
