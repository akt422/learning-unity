using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Throw Action", menuName = "Item Action/Throw action")]
public class ThrowItemAction : ItemAction
{ 
    public override void Execute(ItemEntry itemEntry)
    {
        Debug.Log("Throw action");
        Bag.RemoveEntry(itemEntry);
    }
}