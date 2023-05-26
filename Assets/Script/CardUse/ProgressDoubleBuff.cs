using UnityEngine;

[CreateAssetMenu(fileName = "ProgressDoubleBuff", menuName = "CardAction/ProgressDoubleBuff", order = 0)]
public class ProgressDoubleBuff : CardAction
{
    public ProjectProgressHandler progressHandler;
    public override void Use()
    {
        progressHandler.AddDoubleBuff();
    }
}