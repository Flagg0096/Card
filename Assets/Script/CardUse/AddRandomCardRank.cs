using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Random 3 from Rank", menuName = "CardAction/Random 3 from Rank", order = 0)]
public class AddRandomCardRank : CardAction
{
    public int rank;
    public override void Use()
    {
        FindAnyObjectByType<UIAddCardMenu>().Random3AmongRankMenu(rank);
    }
}
