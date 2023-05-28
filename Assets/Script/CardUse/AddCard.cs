using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Action/Add Card")]
public class AddCard : CardAction
{
    public CardData cardData;
    public override void Use()
    {
        FindAnyObjectByType<DeckManager>().AddCardtoHand(cardData);
    }
}
