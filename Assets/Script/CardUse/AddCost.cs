using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Action/Add Cost")]
public class AddCost : CardAction
{
    public int value;
    public override void Use()
    {
        FindAnyObjectByType<CostManager>().AddCost(value);
    }
}
