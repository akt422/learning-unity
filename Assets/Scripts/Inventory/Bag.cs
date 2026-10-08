using System;
using System.Collections.Generic;
using UnityEngine;

public static class Bag
{
    private static List<ItemEntry> items = new List<ItemEntry>();
    public static event Action OnBagChanged;
    
    public static void Clear()
    {
        items.Clear();
        OnBagChanged?.Invoke();
    }

    public static void AddItem(ItemData itemData, int amount = 1) // amount can be passed as 3 if 3 are picked up, by default 1.
    {
        foreach (ItemEntry i in items)
        {
            if (i.Item == itemData)
            {
                i.Count +=  amount;
                OnBagChanged?.Invoke();
                return;
            }
        }
        ItemEntry newEntry = new ItemEntry(
            itemData, 
            amount);
        items.Add(newEntry);
        OnBagChanged?.Invoke();
    }

    public static void RemoveItem(ItemEntry item)
    {
        if (item.Count == 1)
        {
            items.Remove(item);
            OnBagChanged?.Invoke();
            return;
        }
        item.Count--;
        OnBagChanged?.Invoke();
    }
    
    public static bool RemoveItems(ItemData itemData, int count = 1)
    {
        if (count <= 0)
            return false;
        foreach (ItemEntry entry in items)
        {
            if (entry.Item != itemData)
                continue;

            if (entry.Count < count)
                return false;

            if (entry.Count == count)
            {
                items.Remove(entry);
            }
            else
            {
                entry.Count -= count;
            }

            OnBagChanged?.Invoke();
            return true;
        }
        return false;
    }
    
    public static void RemoveEntry(ItemEntry item)
    {
        items.Remove(item);
        OnBagChanged?.Invoke();
    }
    
    public static ItemEntry GetItem(int index)
    {
        return items[index];
    }
    public static List<ItemEntry> Items => items;

    public static bool HasItem(ItemData item, int amount = 1)
    {
        foreach (ItemEntry entry in items)
        {
            if (entry.Item == item && entry.Count >= amount)
                return true;
        }

        return false;
    }
}