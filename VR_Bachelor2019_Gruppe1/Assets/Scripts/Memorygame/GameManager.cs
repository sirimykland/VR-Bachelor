﻿/*
 * 
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //private Material[] backsides { get; set; }
    private Card[] cards;

    private bool _init = false;

    private Text levelText;
    private Text pointsText;
    private Text pairsText;
    private Text attemptsText;

    private AudioSource source;
    private AudioClip positiveSound;

    private int points;
    private int pairs;
    private int attempts;
    private bool lastAttemptSuccessful;

    public bool lockState = true;
    
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        CheckCards();
    }

    public void InitializeCards(Material[] backsides, int level){

        levelText.text = "Level: "+level;
        points = 0;
        pairs = 8;
        attempts = 0;
        lastAttemptSuccessful = false;


        // 
        for (int i = 0; i < 8; i++){
            for (int j = 0; j < 2; j++){
                bool test = false;
                int choice = 0;
                while (!test){
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
        lockState = false;

        if (!_init) { 
            _init = true;
        }
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
        SetLockState(true);

        int x = 0;
        if(cards[c[0]].CardValue ==  cards[c[1]].CardValue && cards[c[0]].CardType != cards[c[1]].CardType)
        {
            x = 2;
            pairs--;
            pairsText.text = "Par igjen: "+pairs;
            source.PlayOneShot(positiveSound, 0.4f);

            Points(true, cards[c[0]].TimesFlipped, cards[c[1]].TimesFlipped);
            //Debug.Log("Cards matches.");
            if (pairs == 0)
            {
                StartCoroutine(GameOver());
            }
        }
        else
        {
            attempts++;
            attemptsText.text = "Forsøk: "+ attempts;

            Points( false, cards[c[0]].TimesFlipped, cards[c[1]].TimesFlipped);
        }
        for (int i =0; i<c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().State = x;
            cards[c[i]].GetComponent<Card>().FailedAttempt();
        }
        SetLockState(false);
    }

    /*  The player gets 40 points for each pairs that he or she matches,
     *  If the player manages to match 2 pairs in a row, the points will be doubled.
     *  For each mistake the player looses at least -10 points for each mistake, 
     *  NOTE: if the card have been flipped before this number will increase.  
     *   ex:    timesflipped1 =number_of_times_the_first_card_have_been_flipped
     *          timesflipped2 =number_of_times_the_second_card_have_been_flipped
     *          points+= -5*timesflipped1 + -5*timesflipped2;
     */
    private void Points(bool succesStatus, int timesflipped1, int timesflipped2)
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

        // update blackboard:
        pointsText.text = "Poeng: " + points;
    }

    private IEnumerator GameOver()
    {
        Global.score = points;
        Global.gameOver = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(Global.scenes[3]);
    }
    
}
