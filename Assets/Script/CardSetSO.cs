using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAmount
{
    public CardData cardData;
    public int amount = 1;
}

[CreateAssetMenu(menuName = "Card Set")]
public class CardSetSO : ScriptableObject
{
    public List<CardAmount> cards;
    public List<CardData> GetList()
    {
        List<CardData> result = new List<CardData>();
        foreach (var cardAmount in cards)
        {
            for (int i = 0; i < cardAmount.amount; i++)
            {
                result.Add(cardAmount.cardData);
            }
        }

        return result;
    }
}