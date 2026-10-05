using System.Collections.Generic;
using System.IO;
using UnityEditor.Overlays;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    void Start()
    {
        // LoadGame();
    }
    
    public void SaveGame()
    {
        Vector2 position = player.transform.position;
        SaveData data = new SaveData();
        
        data.playerX = position.x;
        data.playerY = position.y;

        List<ItemEntry> entries = Bag.Items;

        foreach (ItemEntry entry in entries)
        {
            SavedItemEntry savedItemEntry = new SavedItemEntry();
            savedItemEntry.itemId = entry.Item.ItemId;
            savedItemEntry.count = entry.Count;
            data.items.Add(savedItemEntry);
        }


        string json = JsonUtility.ToJson(data, true);
        string path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, json);

        Debug.Log("Game saved to: " + path);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (!File.Exists(path))
        {
            Debug.Log("No save file found");
            return;
        }
        string json = File.ReadAllText(path);

        SaveData data = JsonUtility.FromJson<SaveData>(json);

        player.transform.position = new Vector3(
            data.playerX,
            data.playerY,
            player.transform.position.z //0
        );
        Debug.Log("Game loaded");
    }
}