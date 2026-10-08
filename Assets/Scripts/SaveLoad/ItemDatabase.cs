using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item DB", menuName = "Item/Database")]
public class ItemDatabase : ScriptableObject
{
    [SerializeField] private List<ItemData> items;
    
    public List<ItemData> Items => items;

    public ItemData GetItemByItemId(string itemId)
    {
        foreach (ItemData item in items)
        {
            if (item.ItemId == itemId)
                return item;
        }
        return null;
    }
}