using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Material[] backsides { get; set; }
    public Card[] cards;

    private bool _init = false;

    public Text pointsText;
    public Text pairsText;
    public Text attemptsText;

    public AudioClip positiveSound;
    private AudioSource source;

    private int points;
    private int pairs;
    private int attempts;
    private bool lastAttemptSuccessful;
    
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    public void InitializeCards(){
        points = 0;
        pairs = 8;
        attempts = 0;
        lastAttemptSuccessful = false;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = UnityEngine.Random.Range(0, cards.Length);
                    test = !(cards[choice].init);
                }
                cards[choice].cardValue = i;
                cards[choice].cardType = j;
                cards[choice].init = true;
            }
        }

        foreach (Card c in cards) { 
            c.SetupGraphics(backsides[(c.cardValue + c.cardValue + c.cardType)]);
        }
       

        if (!_init) { 
            _init = true;
        }
    }
    
    public void Card_OnClick(Card card)
    {
            card.FlipCard();
            CheckCards();
    }

    //
    public void CheckCards()
    {
        List<int> c = new List<int>();

        for(int i=0; i< cards.Length; i++)
        {
            if (cards[i].state == 1)
            {
                c.Add(i);
            }
        }

        if (c.Count == 2)
        {
            CardComparison(c);
        }
    }

    /* Locks cards and compares if they are a match or not.
     * 
     */
    void CardComparison(List<int> c)
    {
        Card.DO_NOT_TURN = true;
        
        int x = 0;
        if(cards[c[0]].cardValue ==  cards[c[1]].cardValue && cards[c[0]].cardType != cards[c[1]].cardType)
        {
            x = 2;
            
            pairsText.text = "Par igjen: "+ --pairs;
            source.PlayOneShot(positiveSound, 0.4f);

            Points(true, cards[c[0]].timesFlipped, cards[c[1]].timesFlipped);
            
            if (pairs == 0)
            {
                StartCoroutine(Global.GoToGameOver(points));
            }
        }
        else
        {
            attempts++;
            attemptsText.text = "Forsok: "+ attempts;
            
            Points( false, cards[c[0]].timesFlipped, cards[c[1]].timesFlipped);
        }

        for (int i =0; i<c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            StartCoroutine(cards[c[i]].GetComponent<Card>().RotateBack());
        }
        
    }

    /*  The player gets 40 points for each pairs that he or she matches,
     *  If the player manages to match 2 pairs in a row, the points will be doubled.
     *  For each mistake the player looses at least -10 points for each mistake, 
     *  NOTE: if the card have been flipped before this number will increase.  
     *   ex:    timesflipped1 =number_of_times_the_first_card_have_been_flipped
     *          timesflipped2 =number_of_times_the_second_card_have_been_flipped
     *          points+= -5*timesflipped1 + -5*timesflipped2;
     */
    public void Points(bool succesStatus, int timesflipped1, int timesflipped2)
    {
        if (succesStatus && lastAttemptSuccessful)
        {
            points += 80;
        }
        else if (succesStatus)
        {
            points += 40;
        }
        else if (!succesStatus)
        {
            points += -5*timesflipped1 + -5*timesflipped2;
        }
        lastAttemptSuccessful = succesStatus;

        pointsText.text = "Poeng: " + points;
    }
    
}
