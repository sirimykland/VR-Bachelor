using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeAtomsGameManager : MonoBehaviour {
    private bool _init = false;
    public Molecule[] Molecules;
    public Atom[] Atoms;
    public int moleculesLeft;

    public Text playerText;
    public Text scoreText;
    private int points;

    // Use this for initialization
    void Start () {
        playerText.text = "Spiller: "+Global.username;
        scoreText.text = "Poeng: 0";
        Initialize();
	}

    // Update is called once per frame
	void Update(){
        if(moleculesLeft == 0)
        {
            Debug.Log("gameover");
            GameOver();
        }
    }

    public void Points(int badHits, int electrons)
    {
        if (badHits==0)
        {
            points += electrons * 10;
        }
        else
        {
            points = -badHits * electrons;
        }
        //lastAttemptSuccessful = succesStatus;

        // update scoreboard
        scoreText.text = "Poeng: " + points;
    }


    // set up wall of 9 atoms
    void Initialize()
    {
        ListShuffeler.Shuffle(Atoms);
        int index = 0;
        moleculesLeft = Molecules.Length;
        foreach (Molecule m in Molecules)
        {
            //Debug.Log("outer "+Atoms[index].GetComponent<Atom>().Outer+ (Atoms[index].GetComponent<Atom>().Outer == 0));
            do{
                index++;
                index=(index < Atoms.Length) ?  index : 0 ;
                //Debug.Log(Atoms.Length+"  "+Atoms[index] +"  " + index);
            } while (Atoms[index].GetComponent<Atom>().Outer == 0);
           
            m.SetupWall(Atoms[index]); //post incrementation
        }
        _init = true;
    }

    public void GameOver()
    {
        Global.score = points;
        Global.gameOver = true;
        StartCoroutine(Global.GoToGameOver());
    }


}
