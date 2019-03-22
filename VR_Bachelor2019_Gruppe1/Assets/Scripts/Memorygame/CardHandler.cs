using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour
{
    public GameManager gameManager;

    public void Card_OnClick(Card card)
    {
        if (!gameManager.lockState){
            card.FlipCard();
        }
    }
}
