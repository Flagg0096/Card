using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardInfo
{
    public int id;
    public int rank;
    public int cost;
    public string cardName;
    [TextArea(2, 10)]
    public string description;
}
[CreateAssetMenu(menuName = "Card Info")]
public class CardInfoSO : ScriptableObject
{
    [field: SerializeField] public List<CardInfo> cardInfos { get; private set; }
    public CardInfo GetCardInfo(int id)
    {
        return cardInfos.Find(card => card.id == id);
    }
}
