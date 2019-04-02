/* EscapeAtomsGameManager.cs - 02.04.2019
 * 
 * 
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeAtomsGameManager : MonoBehaviour {
    
    // Lists filled with GameObjects set in inspector.
    public Molecule[] Molecules;
    public Atom[] Atoms;

    // Text components.
    public Text playerText;
    public Text scoreText;

    public int moleculesLeft;
    private int points;
    private bool init = false;

    // Use this for initialization.
    void Start () {
        Global.level = 1;
        points = 0;
        playerText.text = "Spiller: "+Global.username;
        scoreText.text = "Poeng: "+ points;
        Initialize();
	}

    // Update is called once per frame and checks if there are any molecules left.
	void Update(){
        if(moleculesLeft == 0)
        {
            StartCoroutine(Global.GoToGameOver(points));
        }
    }

    // Initializes the Molecule placeholders with non-stable atoms.
    void Initialize()
    {
        ListShuffeler.Shuffle(Atoms);
        int i = 0;
        moleculesLeft = Molecules.Length;

        foreach (Molecule mol in Molecules)
        {
            do {
                i = (++i < Atoms.Length) ? i : 0;
            } while (Atoms[i].GetComponent<Atom>().Outer == 0);
           
            mol.SetupWall(Atoms[i]);
        }
        init = true;
    }

    // Adds points and updates score text.
    public void Points(int badHits, int electrons)
    {
        if (badHits == 0)
        {
            points += electrons * 10;
        }
        else
        {
            points += -(++badHits) * electrons;
        }

        scoreText.text = "Poeng: " + points;
    }
}
