using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Action/Add 1 Card From N")]
public class Add1CardFromNCard : CardAction
{
    public int N = 3;
    public CardSetSO cardSet;
    List<CardData> pool;
    List<CardData> result;
    public override void Use()
    {
        pool = new List<CardData>();
        result = new List<CardData>();

        pool.AddRange(cardSet.GetList());

        for (int i = 0; i < N; i++)
        {
            CardData cardData = pool[Random.Range(0, pool.Count)];
            result.Add(cardData);
            pool.RemoveAll(item => item == cardData);
        }

        FindAnyObjectByType<UIAddCardMenu>().AddCardFrom(result);
    }
}
