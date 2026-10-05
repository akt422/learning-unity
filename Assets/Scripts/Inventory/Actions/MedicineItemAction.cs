using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item Action", menuName = "Item Action/Medicine action")]
public class MedicineItemAction : ItemAction
{ 
    public override void Execute(ItemEntry itemEntry)
    {
        Debug.Log("Medicine action");
        Bag.RemoveItem(itemEntry);
    }
}