using UnityEngine;

[CreateAssetMenu(menuName = "Card Action/Add Progress Double Buff")]
public class ProgressDoubleBuff : CardAction
{
    public ProjectProgressHandler progressHandler;
    public override void Use()
    {
        progressHandler.AddDoubleBuff();
    }
}