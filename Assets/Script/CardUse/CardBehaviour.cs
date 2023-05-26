using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    public CardData cardData;
    public CostManager costManager;



    public void Use() 
    {
        if (costManager.CanUse(cardData.cost))
        {
            costManager.Use( cardData.cost);
            
            foreach (var action in cardData.actions)
            {
                action.Use();
            }
        };
    }

    public bool CanUse()
    {
        return costManager.CanUse(cardData.cost);
    }
}
