/* EscapeAtomsGameManager.cs - 02.04.2019
 * Manages the 
 * 
 */
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EscapeAtomsGameManager : MonoBehaviour {

    // Public Prefabs and GameObjects assigned in Inspector.
    public Molecule[] Molecules;
    public Atom[] StarterAtoms;
    public Text playerText;
    public Text scoreText;

    
    public int moleculesLeft;
    private int points;
    private bool init = false;

    // Start is called before the first frame update
    void Start () {
        Global.level = 1;
        points = 0;
        playerText.text = "Spiller: "+Global.username;
        scoreText.text = "Poeng: "+ points;
        Initialize();
    }

    // Update is called once per frame and checks if there are any molecules left,
    // -if not, start coroutine.
	void Update(){
        if(moleculesLeft == 0)
        {
            StartCoroutine(Global.GoToGameOver(points));
        }
    }

    // Initializes the Molecule placeholders with non-stable atoms.
    void Initialize()
    {
        ListShuffeler.Shuffle<Atom>(StarterAtoms);
        Atom atom;
        int i = 0;
        moleculesLeft = Molecules.Length;

        foreach (Molecule mol in Molecules)
        {   
            do{
                i++;
                i = (i < StarterAtoms.Length) ? i : 0;
                
                atom = StarterAtoms[i];
                atom.SetState();//atom initialization

            } while (atom.outer == 0);

            mol.SetupWall(atom);
        }
        if(!init)
            init = true;
    }

    // Adds points and updates score text.
    public void Points(int badHits, Atom atom)
    {
        // Calculates the number of electron shells
        int layer = (int)Math.Floor((decimal)(atom.electrons - 2) / 8) + 2;

        if (badHits == 0)
        {
            Debug.Log(atom.atomname + ": 10* layer" + layer + " + outer" + atom.outer + " 5 =" + (layer * 10 + atom.outer * 5));
            points += layer*10 + atom.outer*5;
        }
        else
        {
            Debug.Log(atom.atomname + ": 3* badHits" + badHits + " * layer" + layer + " + outer" + atom.outer + " 3 =" + (-(badHits * layer + atom.outer * 3)));
            points -= 2*badHits * layer  +  atom.outer * 3;
            if (points < 0) points = 0;
        }
        scoreText.text = "Poeng: " + points;
    }

}
