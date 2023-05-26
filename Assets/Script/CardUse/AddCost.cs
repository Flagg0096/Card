using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Add Cost", menuName = "CardAction/Add Cost", order = 0)]
public class AddCost : CardAction
{
    public int value;
    public override void Use()
    {
        FindAnyObjectByType<CostManager>().AddCost(value);
    }
}
