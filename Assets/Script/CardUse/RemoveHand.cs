using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Remove Hand Card", menuName = "CardAction/Remove Hand Card", order = 0)]
public class RemoveHand : CardAction
{
    public CardData cardData;
    public override void Use()
    {
        FindAnyObjectByType<DeckManager>().hands.RemoveCard(cardData);
    }
}
