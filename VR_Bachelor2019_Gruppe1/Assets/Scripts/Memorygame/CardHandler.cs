using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour
{
    public GameManager gameManger;

    public void Card_OnClick(Card card)
    {
        Debug.Log("click");
        if (!gameManger.lockState)
        {
            Debug.Log("click");
            card.FlipCard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameManger.CheckCards();
    }



}
