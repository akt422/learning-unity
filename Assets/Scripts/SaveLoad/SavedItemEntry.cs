using System.Collections.Generic;

[System.Serializable]
public class SavedItemEntry
{
    public string itemId;
    public int count;
}

[System.Serializable]
public class SaveData
{
    public string sceneName;
    public List<SavedItemEntry> items = new List<SavedItemEntry>();
    public float playerX;
    public float playerY;
}
