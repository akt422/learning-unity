using UnityEngine;

[CreateAssetMenu(fileName = "Other Action", menuName = "Item Action/Other action")]
public class OtherItemAction : ItemAction
{
    public override void Execute(ItemEntry itemEntry)
    {
        Debug.Log("Other action");
    }
}