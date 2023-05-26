using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card Data")]
public class CardData : ScriptableObject
{
    public int id;
    public int rank;
    public int cost;
    public string cardName;
    [TextArea(2, 10)]
    public string description;

    public CardAction[] actions;
}
