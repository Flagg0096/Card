using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Action/Draw N Card")]
public class DrawNCard : CardAction
{
    public int amount;
    public override void Use()
    {
        FindAnyObjectByType<DeckManager>().DrawCard(amount);
    }
}
