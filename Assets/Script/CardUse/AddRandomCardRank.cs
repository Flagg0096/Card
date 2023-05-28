using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Action/Random 3 from Rank")]
public class AddRandomCardRank : CardAction
{
    public int rank;
    public override void Use()
    {
        FindAnyObjectByType<UIAddCardMenu>().Random3AmongRankMenu(rank);
    }
}
