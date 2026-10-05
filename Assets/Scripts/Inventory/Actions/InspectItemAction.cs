using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Inspect Action", menuName = "Item Action/Inspect action")]
public class InspectItemAction : ItemAction
{ 
    public override void Execute(ItemEntry itemEntry)
    {
        Debug.Log("Inspect action");
    }
}