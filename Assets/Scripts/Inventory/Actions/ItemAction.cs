using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemAction : ScriptableObject
{
    public abstract void Execute(ItemEntry itemEntry);
    
    [SerializeField] private ActionButton buttonConfig;
    public ActionButton ButtonConfig => buttonConfig;
}