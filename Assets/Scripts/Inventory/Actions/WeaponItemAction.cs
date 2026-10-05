using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Action", menuName = "Item Action/Weapon action")]
public class WeaponItemAction : ItemAction
{
    public override void Execute(ItemEntry itemEntry)
    {
        Debug.Log("Weapon action");
    }
}