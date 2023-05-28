using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Action/Add Progress")]
public class AddProgress : CardAction
{
    public ProjectProgress projectProgress;
    public int value = 1;
    public override void Use()
    {
        projectProgress.AddProgress(value);
    }
}
