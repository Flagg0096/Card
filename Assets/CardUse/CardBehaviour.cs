using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    public CardInfo cardInfo;
    public CostManager costManager;



    public void Use() 
    {
        if (costManager.CanUse(cardInfo.cost))
        {
            costManager.Use( cardInfo.cost);
            
            foreach (var action in cardInfo.actions)
            {
                action.Use();
            }
        };
    }

    public bool CanUse()
    {
        return costManager.CanUse(cardInfo.cost);
    }
}
