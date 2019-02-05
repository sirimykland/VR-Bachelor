using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Material[] backsides;
    

    public Card[] cards;
    public Text matchText;

    private bool _init = false;
    private int matches = 8;

    public float m_StartDelay = 3f;             // The delay between the start of RoundStarting and RoundPlaying phases.
    public float m_EndDelay = 3f;               // The delay between the end of RoundPlaying and RoundEnding phases.

    private WaitForSeconds m_StartWait;         // Used to have a delay whilst the round starts.
    private WaitForSeconds m_EndWait;           // Used to have a delay whilst the round or game ends.


    // Update is called once per frame
    void Update(){
        if (!_init)
            InitializeCards();

        if (Input.GetMouseButtonUp(0)) {
            Debug.Log("Pressed button.");
            CheckCards();
        }
    }

    void InitializeCards(){
        // Create the delays so they only have to be made once.
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        for (int i = 1; i < 9; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                //Debug.Log(i + ", " + j);
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = UnityEngine.Random.Range(0, cards.Length);
                    Debug.Log(choice);
                    test = !(cards[choice].Initialized);
                }
                cards[choice].CardValue = i;
                cards[choice].CardType = j;
                cards[choice].Initialized = true;
            }
        }

        foreach (Card c in cards) { 
            c.SetupGraphics(backsides[c.CardValue*2+ c.CardType]);
        }

        if (!_init)
            _init = true;

        Debug.Log("cards initialized");
    }

    public Material GetBackside(int i)
    {
        return backsides[i - 1];
    }

    void CheckCards(){
        List<int> c = new List<int>();
        Debug.Log("Checking cards...");
        for(int i=0; i< cards.Length; i++)
        {
            if (cards[i].State == 1)
            {
                c.Add(i);
                Debug.Log("Card no " + cards[i].CardValue + "was clicked."+ cards[i].State);
            }
        }

        if (c.Count == 2)
        {
            Debug.Log("two cards chosen");
            CardComparison(c);
        }
        Debug.Log("cards have been checked");
    }
    void CardComparison(List<int> c)
    {
        Card.DO_NOT_TURN = true;

        int x = 0;
        if(cards[c[0]].CardValue ==  cards[c[1]].CardValue)
        {
            x = 2;
            matches--;
            matchText.text = "Number of matching pairs left: "+matches;
            Debug.Log("Cards matches.");
            if (matches == 0)
                SceneManager.LoadScene("GameMenu");
            
        }
        for (int i =0; i<c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().State = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }

    }
}
