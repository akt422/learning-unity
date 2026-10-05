using System.Collections.Generic;
using Dialogue;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Item/Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    [SerializeField] private int itemHealth;
    [SerializeField] private ItemType itemType;
    [SerializeField] private Sprite icon;
    [SerializeField] private int count;
    [SerializeField] private List<ItemAction> actions;
    [SerializeField] private string itemId;
    
    public string ItemName => itemName;
    public string Description => description;
    public int ItemHealth => itemHealth;
    public ItemType ItemType => itemType;
    public Sprite Icon => icon;
    public int Count => count;
    public List<ItemAction> Actions => actions;
    public string ItemId => itemId;
}