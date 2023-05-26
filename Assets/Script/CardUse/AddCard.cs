using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddCard", menuName = "CardAction/AddCard", order = 0)]
public class AddCard : CardAction
{
    public CardData cardData;
    public override void Use()
    {
        FindAnyObjectByType<DeckManager>().AddCardtoHand(cardData);
    }
}
