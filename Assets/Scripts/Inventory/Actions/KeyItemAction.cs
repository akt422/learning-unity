using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Key Action", menuName = "Item Action/Key action")]
public class KeyItemAction : ItemAction
{ 
    public override void Execute(ItemEntry itemEntry)
    {
        Debug.Log("Key action");
    }
}