using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddProgress", menuName = "CardAction/AddProgress", order = 0)]
public class AddProgress : CardAction
{
    public ProjectProgress projectProgress;
    public int value = 1;
    public override void Use()
    {
        projectProgress.AddProgress(value);
    }
}
