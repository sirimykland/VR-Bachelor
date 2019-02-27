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
    public Text mistakesText;

    private bool _init = false;
    private int matches = 8;
    private int mistakes = 0;
    
    void Start()
    {
        InitializeCards();
    }

    void InitializeCards(){

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                //Debug.Log(i + ", " + j);
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = UnityEngine.Random.Range(0, cards.Length);
                    //Debug.Log(choice);
                    test = !(cards[choice].Initialized);
                }
                cards[choice].CardValue = i;
                cards[choice].CardType = j;
                cards[choice].Initialized = true;
            }
        }

        foreach (Card c in cards) { 
            c.SetupGraphics(backsides[(c.CardValue + c.CardValue + c.CardType)]);
            //Debug.Log("card no: " + (c.CardValue + c.CardValue + c.CardType) );
        }

        if (!_init)
            _init = true;
    }

    public Material GetBackside(int i){
        return backsides[i - 1];
    }

    public void CheckCards() { 
        List<int> c = new List<int>();

        for(int i=0; i< cards.Length; i++)
        {
            if (cards[i].State == 1)
            {
                c.Add(i);
            }
        }

        if (c.Count == 2)
        {
            CardComparison(c);
        }
    }
    void CardComparison(List<int> c)
    {
        // sets all card to do not turn
        Card.DO_NOT_TURN = true;

        int x = 0;
        if(cards[c[0]].CardValue ==  cards[c[1]].CardValue && cards[c[0]].CardType != cards[c[1]].CardType)
        {
            x = 2;
            matches--;
            matchText.text = "Pairs left: "+matches;
            //Debug.Log("Cards matches.");
            if (matches == 0)
                SceneManager.LoadScene("GameMenu");

        }else
        {
            mistakes++;
            mistakesText.text = "Mistakes made: "+ mistakes;
        }
        for (int i =0; i<c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().State = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }
        

    }
    public void IsGameOver()
    {
        if (Global.gameOver)
            StartCoroutine(Global.GoToGameOver());
    }
    
}
