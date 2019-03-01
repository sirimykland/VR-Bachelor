using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Material[] backsides;
    public Card[] cards;

    private bool _init = false;
<<<<<<< HEAD

    public Text pointsText;
    public Text pairsText;
    public Text attemptsText;

    public AudioClip positiveSound;
    public AudioClip negativeSound;
    private AudioSource source;

    private int points = 0;
    private int pairs = 8;
    private int attempts = 0;
    private bool lastAttemptSuccessful = false;

    public bool lockState = false;
=======
    private int matches = 8;
    private int mistakes = 0;

    public float m_StartDelay = 3f;             // The delay between the start of RoundStarting and RoundPlaying phases.
    public float m_EndDelay = 3f;               // The delay between the end of RoundPlaying and RoundEnding phases.

    private WaitForSeconds m_StartWait;         // Used to have a delay whilst the round starts.
    private WaitForSeconds m_EndWait;           // Used to have a delay whilst the round or game ends.



>>>>>>> parent of ae428086... 27.02.2019
    
    void Start()
    {
        InitializeCards();
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void InitializeCards(){
        // Create the delays so they only have to be made once.
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = UnityEngine.Random.Range(0, cards.Length);
                    test = !(cards[choice].Initialized);
                }
                cards[choice].CardValue = i;
                cards[choice].CardType = j;
                cards[choice].Initialized = true;
            }
        }

        foreach (Card c in cards) { 
            c.SetupGraphics(backsides[(c.CardValue + c.CardValue + c.CardType)]);
        }

        if (!_init)
            _init = true;

        //Debug.Log("cards initialized");
    }

    void SetLockState(bool state)
    {
        if (state)
        {
            Card.DO_NOT_TURN = true;
            lockState = true;
        }else
        {
            Card.DO_NOT_TURN = false;
            lockState = false;
        }
        Debug.Log("lockstate "+ lockState);
        
    }

    public Material GetBackside(int i){
        return backsides[i - 1];
    }

    public void CheckCards() {
        
        List<int> c = new List<int>();
        //Debug.Log("Checking cards...");
        for(int i=0; i< cards.Length; i++)
        {
            if (cards[i].State == 1)
            {
                c.Add(i);
                //Debug.Log("Card no " + cards[i].CardValue + "was clicked."+ cards[i].State);
            }
        }

        if (c.Count == 2)
        {
            //Debug.Log("two cards chosen");
            CardComparison(c);
        }
        //Debug.Log("cards have been checked");
    }
    void CardComparison(List<int> c)
    {
<<<<<<< HEAD
        // sets all card to do not turn
        SetLockState(true);
=======
        Card.DO_NOT_TURN = true;
>>>>>>> parent of ae428086... 27.02.2019

        int x = 0;
        if(cards[c[0]].CardValue ==  cards[c[1]].CardValue && cards[c[0]].CardType != cards[c[1]].CardType)
        {
            x = 2;
            pairs--;
            pairsText.text = "Pairs left: "+pairs;
            source.PlayOneShot(positiveSound, 0.4f);

            Points(true, cards[c[0]].TimesFlipped, cards[c[1]].TimesFlipped);
            //Debug.Log("Cards matches.");
            if (pairs == 0)
            {
                GameOver();
            }
        }
        else
        {
            attempts++;
            attemptsText.text = "Attempts: "+ attempts;

            source.PlayOneShot(negativeSound, 0.4f);

            Points( false, cards[c[0]].TimesFlipped, cards[c[1]].TimesFlipped);
        }
        for (int i =0; i<c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().State = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }
<<<<<<< HEAD
        SetLockState(false);
    }
=======
>>>>>>> parent of ae428086... 27.02.2019

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

        // update scoreboard:
        pointsText.text = "Points: " + points;
    }

    public void GameOver()
    {
        Global.score = points;
        Global.gameOver = true;
        StartCoroutine(Global.GoToGameOver());
    }
    
}
