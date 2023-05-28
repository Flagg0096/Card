using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Action/Remove Hand Card")]
public class RemoveHand : CardAction
{
    public CardData cardData;
    public override void Use()
    {
        FindAnyObjectByType<DeckManager>().hands.RemoveCard(cardData);
    }
}
