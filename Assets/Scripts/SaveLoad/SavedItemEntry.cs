using System.Collections.Generic;
using System.IO;
using UnityEditor.Overlays;
using UnityEngine;

[System.Serializable]
public class SavedItemEntry
{
    public string itemId;
    public int count;
}

[System.Serializable]
public class SaveData
{
    public List<SavedItemEntry> items = new List<SavedItemEntry>();
    public float playerX;
    public float playerY;
}
