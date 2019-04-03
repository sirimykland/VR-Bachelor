/* GameManager.cs - 03.04.2019 
 * Manages MemoryGame and contains all behaviour nessecary to play the game,
 * including initializing, rules, and a score function
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    // Public Prefabs and GameObjects assigned in Inspector
    public Material[] backsides { get; set; }
    public Card[]     cards;
    public AudioClip  positiveSound;
    public Text pointsText;
    public Text pairsText;
    public Text attemptsText;


    // Private AudioSource component and variables used in game
    private AudioSource source;
    private int  points;
    private int  pairs;
    private int  attempts;
    private int  attemptsSuccessful;
    private bool init = false;

    // Awake is called after all objects are initialized
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    /* InitializeCards() assigns cardValue, cardType to all cards in the list cards.
     * The card list is shuffled to randomize the cards.
     * the call to .SetUpGraphic() sends the assigned backside material to the card.
     */
    public void InitializeCards(){
        
        points = 0;
        pairs = 8;
        attempts = 0;
        attemptsSuccessful = 0;

        ListShuffeler.Shuffle<Card>(cards);

        int i = 0;
        for (int j = 0; j < pairs; j++)
        {
            for (int k = 0; k < 2; k++)
            {
            i = j * 2 + k;
                cards[i].cardValue = j;
                cards[i].cardType = k;
                cards[i].SetupGraphics(backsides[i]);
                cards[i].init = true;
            }
        }

        if (!init) { 
            init = true;
        }
    }

    // Card_OnClick() calls the clicked card's FlipCard() method and CheckCards().
    public void Card_OnClick(Card card)
    {
            card.FlipCard();
            CheckCards();
    }

    /* CheckCards() iterates through cards[] and if any cards 
     * have state = 1 it is added to a list flipped.
     * If two cards are flipped, CardComparison() is called. 
     */
    void CheckCards()
    {
        List<int> flipped = new List<int>();

        for(int i=0; i< cards.Length; i++)
        {
            if (cards[i].state == 1)
            {
                flipped.Add(i);
            }
        }

        if (flipped.Count == 2)
        {
            CardComparison(flipped);
        }
    }

    /* CardComparison() locks all cards and compares if the flipped cards are a match or not.
     * Cards are a match if they have the same cardValue and different cardTypes 
     * If match:    the newState is set to 2, meaning it is matched 
     *              isSuccessful is set to true,
     *              #pairs left is decremented,
     *              sound is played, 
     *              checks if there are any unmached pairs left.
     * If failed:   #attempts is incremented. 
     * 
     * Points() are called,  
     * and for both cards the new state of the card is set and isFailedCheck() is called
     */
    void CardComparison(List<int> c)
    {
        Card.DO_NOT_TURN = true;

        bool isSuccessful= false;
        int newState = 0;

        if(cards[c[0]].cardValue ==  cards[c[1]].cardValue && cards[c[0]].cardType != cards[c[1]].cardType)
        {
            newState = 2;
            isSuccessful = true;

            pairsText.text = "Par igjen: "+ (--pairs);
            source.PlayOneShot(positiveSound, 0.4f);
            
            if (pairs == 0)  StartCoroutine(Global.GoToGameOver(points));

        }else
        {
            attemptsText.text = "Forsok: "+  (++attempts);
        }

        Points(isSuccessful, cards[c[0]].timesFlipped, cards[c[1]].timesFlipped);

        for (int i =0; i<c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = newState;
            StartCoroutine(cards[c[i]].GetComponent<Card>().IsFailedCheck());
        }
        
    }

    /*  The player gets 40 points for each pairs that he or she matches,
     *  If the player manages to match multiple pairs in a row, the points will be multiplied for each time.
     *  For each mismatched pair the score goes down at least 5 x total #flipped points, 
     *  
     *          timesflipped1 : #the_first_card_have_been_flipped
     *          timesflipped2 : #the_second_card_have_been_flipped
     */
    void Points(bool isSuccessful, int timesflipped1, int timesflipped2)
    {   
        if (isSuccessful)
        {
            attemptsSuccessful++;
            points += 40 * attemptsSuccessful;
        }
        else if (!isSuccessful)
        {
            attemptsSuccessful = 0;
            points -= 5 * (timesflipped1 + timesflipped2);
        }
        pointsText.text = "Poeng: " + points;
    }
    
}
