/* EscapeAtomsGameManager.cs - 02.04.2019
 * Manages the 
 * 
 */
using System;
using UnityEngine;
using UnityEngine.UI;

public class EscapeAtomsGameManager : MonoBehaviour {

    // Public Prefabs and GameObjects assigned in Inspector.
    public Molecule[] Molecules;
    public Atom[] StarterAtoms;
    public Text playerText;
    public Text scoreText;

    
    public static int moleculesLeft;
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
        ListShuffeler.Shuffle(StarterAtoms);

        int i = 0;
        moleculesLeft = Molecules.Length;

        foreach (Molecule mol in Molecules)
        {
            do {
                i = (++i < StarterAtoms.Length) ? i : 0;
            } while (StarterAtoms[i].GetComponent<Atom>().outer == 0);
           
            mol.SetupWall(StarterAtoms[i]);
        }
        
        init = true;
    }

    // Adds points and updates score text.
    public void Points(int badHits, int electrons)
    {
        if (badHits == 0)
        {
            points += electrons * 5;
        }
        else
        {
            points -= (++badHits) * electrons;
        }

        scoreText.text = "Poeng: " + points;
    }
}
