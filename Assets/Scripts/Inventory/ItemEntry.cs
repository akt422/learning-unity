using UnityEngine;

public class ItemEntry
{
    public ItemData Item { get; private set; }
    public int Count { get; set; }

    public ItemEntry(ItemData item, int count)
    {
        Item = item;
        Count = count;
    }
}